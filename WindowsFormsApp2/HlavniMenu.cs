using BusinessLayer;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class HlavniMenu : Form
    {
        public HlavniMenu()
        {
            InitializeComponent();
            AktualniUzivatel<TrenerModel>.Uzivatel = new TrenerModel(1, "Uma", "Bowers", DateTime.Now.ToUniversalTime(), "email", "telefon", "Kulturistika");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new PrehledZadosti(this).Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new NovyPlanSelect(this).Show();
        }
    }
}
