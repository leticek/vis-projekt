﻿using PresentationLayer;
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
        private Form previousForm;

        public NovyPlanNameSelect(Form previous)
        {
            InitializeComponent();
            this.previousForm = previous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();

        }

        private void NovyPlanNameSelect_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if (NovyTreninkController.checkName(textBox1.Text))
                {
                    Hide();
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
