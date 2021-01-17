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
    public partial class NovyPlanNameSelect : Form
    {
        public Form previousForm;
        public Form nextForm;

        public NovyPlanNameSelect(Form previous)
        {
            InitializeComponent();
            this.previousForm = previous;
        }

        private void Zpet_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();

        }

        private void pokracovat_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if (NovyTreninkController.CheckName(textBox1.Text))
                {
                    NovyTreninkController.NovyTreninkName = textBox1.Text;
                    if (nextForm == null)
                        nextForm = new NovyPlanKonfigurace(this);
                    Hide();
                    nextForm.Show(this);

                }
                else
                {
                    MessageBox.Show("Trénink již existuje", "Chyba", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Jméno nesmí být prázdné.", "Chyba", MessageBoxButtons.OK);
            }

        }
    }
}
