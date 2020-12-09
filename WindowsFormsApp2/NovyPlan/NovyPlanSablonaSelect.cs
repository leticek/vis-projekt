using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class NovyPlanSablonaSelect : Form
    {
        private Form previousForm;
        public NovyPlanSablonaSelect(Form previous)
        {
            InitializeComponent();
            this.previousForm = previous;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();
        }
    }
}
