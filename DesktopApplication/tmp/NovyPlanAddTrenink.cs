﻿using System;
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

        public Form previous; 
        public NovyPlanAddTrenink(Form previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void NovyPlanAddTrenink_Load(object sender, EventArgs e)
        {
                NovyTreninkController.populateAddTrenink(dataGridView1, dataGridView2, cilLabel, trvaniLabel, obtiznostLabel);
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

        private void Zpet_Click(object sender, EventArgs e)
        {
            Hide();
            previous.Show();
        }

        private async void ulozit_Click(object sender, EventArgs e)
        {
            if(await NovyTreninkController.saveTrenink(dataGridView2))
            {
                MessageBox.Show("Trénink se uložil", "OK", MessageBoxButtons.OK);
                System.Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Musíte přidat alespoň 3 tréninky.", "Chyba", MessageBoxButtons.OK);
            }
        }
    }
}
