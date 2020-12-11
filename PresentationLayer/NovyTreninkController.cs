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
        private static List<string> loadedSablona;

        public static bool checkName(string name)
        {
            TrenerModel trener = AktualniUzivatel<TrenerModel>.Uzivatel;
            List<TreninkModel> result = trener.Treninky.Where(x => x.Nazev.Equals(name)).ToList();
            if (result.Count > 0) return false;
            TreninkovyPlanModel.NazevPlanu = name;
            TreninkovyPlanModel.TrenerId = AktualniUzivatel<TrenerModel>.Uzivatel.Id;
            return true;
        }

        public static async void sablonaSelect(string name)
        {
            TreninkovyPlanModel = await TreninkovyPlanModel.GetByName(AktualniUzivatel<TrenerModel>.Uzivatel.Id, name);
        }

        public static async void loadPlans(ComboBox comboBox)
        {
            List<TreninkovyPlanModel> result  = await TreninkovyPlanModel.GetByTrenerId(AktualniUzivatel<TrenerModel>.Uzivatel.Id);
            loadedSablona = new List<string>();
            result.ForEach(x => loadedSablona.Add(x.NazevPlanu));
            comboBox.Items.Add("-");
            comboBox.SelectedIndex = 0;
            result.ForEach(x => comboBox.Items.Add(x.NazevPlanu));
        }

        public static void loadPlanConfiguration(ComboBox obtiznostCB, ComboBox cilCB, DateTimePicker dateTimePicker1, TextBox textBox1)
        {
            MessageBox.Show(TreninkovyPlanModel.ToString());
            setCilPlanu(cilCB);
            setObtiznost(obtiznostCB);
            cilCB.SelectedIndex  = (int)Enum.Parse(typeof(CilPlanu), TreninkovyPlanModel.CilPlanu.ToString());
            obtiznostCB.SelectedIndex = (int)TreninkovyPlanModel.Obtiznost;
            dateTimePicker1.Value = TreninkovyPlanModel.PlatnyDo;
            textBox1.Text = TreninkovyPlanModel.Poznamka;
        }

        public static void populateAddTrenink(DataGridView dataGridView1, DataGridView dataGridView2, Label cilLabel, Label trvaniLabel, Label obtiznostLabel)
        {
            foreach (TreninkModel treninkModel in AktualniUzivatel<TrenerModel>.Uzivatel.Treninky)
            {
                if (TreninkovyPlanModel.Treninky.Contains(treninkModel.Id))
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView2.RowTemplate.Clone();
                    row.CreateCells(dataGridView2, treninkModel.Nazev);
                    dataGridView2.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                    row.CreateCells(dataGridView1, treninkModel.Nazev);
                    dataGridView1.Rows.Add(row);
                }
            }
            cilLabel.Text = cilPlanuValues[(int)TreninkovyPlanModel.CilPlanu];
            obtiznostLabel.Text = obtiznostPlanuValues[(int)TreninkovyPlanModel.Obtiznost];
            trvaniLabel.Text = TreninkovyPlanModel.PlatnyDo.ToShortDateString();
        }

        public static async Task<bool> saveTrenink(DataGridView dataGridView2)
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

        public static bool ZkontrolujPocetTreninku()
        {
            return TreninkovyPlanModel.Treninky.Count <= 0 ? true : false;
        }
    }
}
