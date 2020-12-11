using PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class NovyPlanSablonaSelect : Form
    {
        public Form previousForm;
        public Form nextForm;
        public NovyPlanSablonaSelect(Form previous)
        {
            InitializeComponent();
            this.previousForm = previous;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();
        }

        private void NovyPlanSablonaSelect_Load(object sender, EventArgs e)
        {
            NovyTreninkController.loadPlans(comboBox1);
        }

        private void Pokracovat_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                if (nextForm == null)
                    nextForm = new NovyPlanNameSelect(this);
                
                NovyTreninkController.sablonaSelect(comboBox1.SelectedItem.ToString());
                Hide();
                nextForm.Show();
            }
        }
    }
}
