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

        public static bool checkName(string name)
        {
            TrenerModel trener = AktualniUzivatel<TrenerModel>.Uzivatel;
            List<TreninkModel> result = trener.Treninky.Where(x => x.Nazev.Equals(name)).ToList();
            if (result.Count > 0) return false;
            TreninkovyPlanModel.NazevPlanu = name;
            TreninkovyPlanModel.TrenerId = AktualniUzivatel<TrenerModel>.Uzivatel.Id;
            return true;
        }

        public static void populateAddTrenink(DataGridView dataGridView1)
        {
            foreach(TreninkModel treninkModel in AktualniUzivatel<TrenerModel>.Uzivatel.Treninky)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                row.CreateCells(dataGridView1, treninkModel.Nazev);
                dataGridView1.Rows.Add(row);
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
            string[] values = { "Začátečník", "Středně pokročilý", "Pokročilý", "Expert" };
            comboBox.Items.AddRange(values);
            comboBox.SelectedIndex = 0;
        }

        public static void setCilPlanu(ComboBox comboBox)
        {
            string[] values = { "Redukce tuku", "Tvarování postavy", "Zvýšení síly", "Zlepšení kondice" };
            comboBox.Items.AddRange(values);
            comboBox.SelectedIndex = 0;
        }

        public static void savePlanConfiguration(DateTime pickedDate, string note, int cilPlanu, int obtiznostPlanu)
        {
            TreninkovyPlanModel.Obtiznost = (ObtiznostTreninkovehoPlanu)obtiznostPlanu;
            TreninkovyPlanModel.CilPlanu = (CilPlanu)cilPlanu;
            TreninkovyPlanModel.PlatnyDo = pickedDate;
        }
    }
}
