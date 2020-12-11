using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PresentationLayer;

namespace DesktopApplication
{
    public partial class NovyPlanKonfigurace : Form
    {

        public Form previousForm;
        public Form nextForm;
        public NovyPlanKonfigurace(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
        }

        private void zpet_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();
        }

        private void pokracovat_Click(object sender, EventArgs e)
        {
            if (NovyTreninkController.checkPlanConfiguration(dateTimePicker1.Value, textBox1.Text))
            {
                if (nextForm == null)
                    nextForm = new NovyPlanAddTrenink(this);
                NovyTreninkController.savePlanConfiguration(dateTimePicker1.Value, textBox1.Text, cilCB.SelectedIndex, obtiznostCB.SelectedIndex);
                Hide();
                nextForm.Show();
            }
            else
            {
                MessageBox.Show("Prosím vyplňte všechny pole. (Plán musí trvat aspoň 10 dní)", "Chyba", MessageBoxButtons.OK);
            }
        }

        private void NovyPlanKonfigurace_Load(object sender, EventArgs e)
        {
            if (previousForm.GetType() == typeof(NovyPlanNameSelect) && NovyTreninkController.ZkontrolujPocetTreninku())
            {
                NovyTreninkController.setObtiznost(obtiznostCB);
                NovyTreninkController.setCilPlanu(cilCB);
            }
            else
            {
                NovyTreninkController.loadPlanConfiguration(obtiznostCB, cilCB, dateTimePicker1, textBox1);
            }

        }
    }
}
