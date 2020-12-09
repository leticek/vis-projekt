
namespace DesktopApplication
{
    partial class NovyPlanKonfigurace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.obtiznostCB = new System.Windows.Forms.ComboBox();
            this.cilCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pokracovat = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trvání plánu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label2.Location = new System.Drawing.Point(242, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Poznámky";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label3.Location = new System.Drawing.Point(10, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Obtížnost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cíl plánu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F);
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 40);
            this.label5.TabIndex = 4;
            this.label5.Text = "Základni informace";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(242, 96);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(569, 159);
            this.textBox1.TabIndex = 6;
            // 
            // obtiznostCB
            // 
            this.obtiznostCB.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.obtiznostCB.FormattingEnabled = true;
            this.obtiznostCB.Location = new System.Drawing.Point(15, 147);
            this.obtiznostCB.Name = "obtiznostCB";
            this.obtiznostCB.Size = new System.Drawing.Size(170, 38);
            this.obtiznostCB.TabIndex = 7;
            // 
            // cilCB
            // 
            this.cilCB.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.cilCB.FormattingEnabled = true;
            this.cilCB.Location = new System.Drawing.Point(15, 217);
            this.cilCB.Name = "cilCB";
            this.cilCB.Size = new System.Drawing.Size(170, 38);
            this.cilCB.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 20);
            this.button1.TabIndex = 9;
            this.button1.Text = "Zpět";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.zpet_Click);
            // 
            // pokracovat
            // 
            this.pokracovat.Location = new System.Drawing.Point(735, 293);
            this.pokracovat.Name = "pokracovat";
            this.pokracovat.Size = new System.Drawing.Size(76, 24);
            this.pokracovat.TabIndex = 10;
            this.pokracovat.Text = "Pokračovat";
            this.pokracovat.UseVisualStyleBackColor = true;
            this.pokracovat.Click += new System.EventHandler(this.pokracovat_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 95);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // NovyPlanKonfigurace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 329);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pokracovat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cilCB);
            this.Controls.Add(this.obtiznostCB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NovyPlanKonfigurace";
            this.Text = "NovyPlanKonfigurace";
            this.Load += new System.EventHandler(this.NovyPlanKonfigurace_Load);
            this.Shown += new System.EventHandler(this.NovyPlanKonfigurace_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox obtiznostCB;
        private System.Windows.Forms.ComboBox cilCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button pokracovat;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}