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
    }
}
