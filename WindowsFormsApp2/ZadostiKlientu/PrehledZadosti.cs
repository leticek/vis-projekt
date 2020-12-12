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
    public partial class PrehledZadosti : Form
    {
        private Form previousForm;
        public PrehledZadosti(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Close();
        }

        private void PrehledZadosti_Load(object sender, EventArgs e)
        {
            try
            {
                ZadostiKlientuController.LoadZadosti(dataGridView1);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
