﻿using System;
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
    public partial class NovyPlanSelect : Form
    {
        public NovyPlanSelect()
        {
            InitializeComponent();
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new NovyPlanNameSelect().Show();
            this.Close();
        }

     
    }
}