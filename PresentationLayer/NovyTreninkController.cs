using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public static class NovyTreninkController
    {
        static public string NovyTreninkName { get; set; }

        private static TreninkovyPlanModel TreninkovyPlanModel = new TreninkovyPlanModel();
        private static string[] obtiznostPlanuValues = { "Začátečník", "Středně pokročilý", "Pokročilý", "Expert" };
        private static string[] cilPlanuValues = { "Redukce tuku", "Tvarování postavy", "Zvýšení síly", "Zlepšení kondice" };

        public static bool checkName(string name)
        {
            TrenerModel trener = AktualniUzivatel<TrenerModel>.Uzivatel;
            List<TreninkModel> result = trener.Treninky.Where(x => x.Nazev.Equals(name)).ToList();
            if (result.Count > 0) return false;
            TreninkovyPlanModel.NazevPlanu = name;
            TreninkovyPlanModel.TrenerId = AktualniUzivatel<TrenerModel>.Uzivatel.Id;
            return true;
        }

        public static void populateAddTrenink(DataGridView dataGridView1, Label cilLabel, Label trvaniLabel, Label obtiznostLabel)
        {
            foreach (TreninkModel treninkModel in AktualniUzivatel<TrenerModel>.Uzivatel.Treninky)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                row.CreateCells(dataGridView1, treninkModel.Nazev);
                dataGridView1.Rows.Add(row);
            }
            cilLabel.Text = cilPlanuValues[(int)TreninkovyPlanModel.CilPlanu];
            obtiznostLabel.Text = obtiznostPlanuValues[(int)TreninkovyPlanModel.Obtiznost];
            trvaniLabel.Text = TreninkovyPlanModel.PlatnyDo.ToShortDateString();
        }

        public static async Task<bool> saveTrenink(DataGridView dataGridView2, string note)
        {
            if (dataGridView2.Rows.Count >= 3)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    TreninkModel treninkModel = new TreninkModel();
                    treninkModel = await treninkModel.loadFromFirestore((string)row.Cells[0].Value, AktualniUzivatel<TrenerModel>.Uzivatel.Id);
                    TreninkovyPlanModel.TreninkModels.Add(treninkModel);
                }
                TreninkovyPlanModel.Id = new Random().Next();
                TreninkovyPlanModel.Poznamka = note;
                TreninkovyPlanModel.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkPlanConfiguration(DateTime pickedDate, string note)
        {
            if (note.Length > 0 && pickedDate.CompareTo(DateTime.Now.AddDays(10)) >= 0)
            {
                return true;
            }
            return false;
        }

        public static void setObtiznost(ComboBox comboBox)
        {
            comboBox.Items.AddRange(obtiznostPlanuValues);
            comboBox.SelectedIndex = 0;
        }

        public static void setCilPlanu(ComboBox comboBox)
        {
            comboBox.Items.AddRange(cilPlanuValues);
            comboBox.SelectedIndex = 0;
        }

        public static void savePlanConfiguration(DateTime pickedDate, string note, int cilPlanu, int obtiznostPlanu)
        {
            TreninkovyPlanModel.Obtiznost = (ObtiznostTreninkovehoPlanu)obtiznostPlanu;
            TreninkovyPlanModel.CilPlanu = (CilPlanu)cilPlanu;
            TreninkovyPlanModel.PlatnyDo = pickedDate;
            TreninkovyPlanModel.Poznamka = note;
        }
    }
}
