﻿using PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.ZadostiKlientu;

namespace DesktopApplication
{
    public partial class PrehledZadosti : Form
    {
        private readonly Form previousForm;
        public PrehledZadosti(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
        }

        private void Button1_Click(object sender, EventArgs e)
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

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (!ZadostiKlientuController.HandleMouseClick(dataGridView1, e))
                {
                    new VyriditZadost(dataGridView1, e).Show();

                }
            }
        }
    }
}
