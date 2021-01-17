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

namespace WindowsFormsApp2.ZadostiKlientu
{
    public partial class VyriditZadost : Form
    {
        private DataGridView dataGrid;
        private DataGridViewCellMouseEventArgs ev;
        public VyriditZadost(DataGridView dgw, DataGridViewCellMouseEventArgs e)
        {
            InitializeComponent();
            dataGrid = dgw;
            ev = e;
            if (radioButton1.Checked)
            {
                textBox1.Visible = false;
                button3.Visible = false;
            }
        }

        private void Zpet_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Prijmout_Click(object sender, EventArgs e)
        {
            ZadostiKlientuController.PrijmoutZadost(dataGrid, ev);
            ZadostiKlientuController.LoadZadosti(dataGrid);
            Close();
        }

        private void Odmitnout_Click(object sender, EventArgs e)
        {
            if (!ZadostiKlientuController.OdmitnoutZadost(dataGrid, ev, textBox1.Text))
            {
                MessageBox.Show("Je nutné vyplnit důvod odmítnutí");
            }
            else
            {
                ZadostiKlientuController.LoadZadosti(dataGrid);
                Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            button2.Visible = !button2.Visible;
            button3.Visible = !button3.Visible;
        }
    }
}
