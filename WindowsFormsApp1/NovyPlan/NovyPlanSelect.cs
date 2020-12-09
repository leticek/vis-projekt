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
        private Form actualForm;
        private Form novyPlanNameInput;
        private Form novyPlanSablona;




        public NovyPlanSelect()
        {
            InitializeComponent();
            AktualniUzivatel<TrenerModel>.Uzivatel = new TrenerModel(1, "Uma", "Bowers", DateTime.Now.ToUniversalTime(), "email", "telefon", "Kulturistika");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (novyPlanNameInput == null)
                novyPlanNameInput = new NovyPlanNameSelect(this);
            Hide();
            novyPlanNameInput.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (novyPlanSablona == null)
                novyPlanSablona = new NovyPlanSablonaSelect(this);
            Hide();
            novyPlanSablona.Show();

        }

        private void NovyPlanSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
