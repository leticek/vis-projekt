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
    public partial class NovyPlanAddTrenink : Form
    {
        public NovyPlanAddTrenink(Form previous)
        {
            InitializeComponent();
        }

        private void NovyPlanAddTrenink_Load(object sender, EventArgs e)
        {
            NovyTreninkController.populateAddTrenink(dataGridView1);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            dataGridView1.Rows.Remove(row);
            dataGridView2.Rows.Add(row);
        }
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            dataGridView2.Rows.Remove(row);
            dataGridView1.Rows.Add(row);
        }
    }
}
