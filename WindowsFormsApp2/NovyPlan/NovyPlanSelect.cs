using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer;

namespace DesktopApplication
{
    public partial class NovyPlanSelect : Form
    {
        private Form novyPlanNameInput;
        private Form novyPlanSablona;
        private Form previousForm;
        public NovyPlanSelect(Form previous)
        {
            InitializeComponent();
            previousForm = previous;

        }
        private void novyPlan_Select(object sender, EventArgs e)
        {
            if (novyPlanNameInput == null)
                novyPlanNameInput = new NovyPlanNameSelect(this);
            Hide();
            novyPlanNameInput.Show();
        }
        private void pouzitSablonu_Select(object sender, EventArgs e)
        {
            if (novyPlanSablona == null)
                novyPlanSablona = new NovyPlanSablonaSelect(this);
            Hide();
            novyPlanSablona.Show();
        }

        private void NovyPlanSelect_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            previousForm.Show();
        }
    }
}
