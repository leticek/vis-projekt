using BusinessLayer;
using BusinessLayer.Models;
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
            //DataLoader.generateData();
            AktualniUzivatel<TrenerModel>.Uzivatel = new TrenerModel(1, "Uma", "Bowers", DateTime.Now.ToUniversalTime(), "email", "telefon", "Kulturistika");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            new PrehledZadosti(this).Show();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            new NovyPlanSelect(this).Show();
        }





    }
}
