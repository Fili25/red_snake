namespace Snake
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.EndGameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SnakeLengthLabel = new System.Windows.Forms.Label();
            this.A1 = new System.Windows.Forms.Label();
            this.A2 = new System.Windows.Forms.Label();
            this.A3 = new System.Windows.Forms.Label();
            this.A4 = new System.Windows.Forms.Label();
            this.A5 = new System.Windows.Forms.Label();
            this.A10 = new System.Windows.Forms.Label();
            this.A9 = new System.Windows.Forms.Label();
            this.A8 = new System.Windows.Forms.Label();
            this.A7 = new System.Windows.Forms.Label();
            this.A6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EndGameLabel
            // 
            this.EndGameLabel.BackColor = System.Drawing.Color.Black;
            this.EndGameLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndGameLabel.ForeColor = System.Drawing.Color.Red;
            this.EndGameLabel.Location = new System.Drawing.Point(169, 221);
            this.EndGameLabel.Name = "EndGameLabel";
            this.EndGameLabel.Size = new System.Drawing.Size(248, 171);
            this.EndGameLabel.TabIndex = 2;
            this.EndGameLabel.Text = "You Lost!\r\n\r\nThe snake collided with itself\r\n\r\nClick to play again";
            this.EndGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EndGameLabel.Visible = false;
            this.EndGameLabel.Click += new System.EventHandler(this.EndGameLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(48, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 485);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(298, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Snake Length:";
            // 
            // SnakeLengthLabel
            // 
            this.SnakeLengthLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.SnakeLengthLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnakeLengthLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnakeLengthLabel.ForeColor = System.Drawing.Color.Red;
            this.SnakeLengthLabel.Location = new System.Drawing.Point(432, 7);
            this.SnakeLengthLabel.Name = "SnakeLengthLabel";
            this.SnakeLengthLabel.Size = new System.Drawing.Size(59, 35);
            this.SnakeLengthLabel.TabIndex = 14;
            this.SnakeLengthLabel.Text = "1";
            this.SnakeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // A1
            // 
            this.A1.Location = new System.Drawing.Point(0, 0);
            this.A1.Name = "A1";
            this.A1.Size = new System.Drawing.Size(100, 23);
            this.A1.TabIndex = 55;
            // 
            // A2
            // 
            this.A2.Location = new System.Drawing.Point(0, 0);
            this.A2.Name = "A2";
            this.A2.Size = new System.Drawing.Size(100, 23);
            this.A2.TabIndex = 54;
            // 
            // A3
            // 
            this.A3.Location = new System.Drawing.Point(0, 0);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(100, 23);
            this.A3.TabIndex = 53;
            // 
            // A4
            // 
            this.A4.Location = new System.Drawing.Point(0, 0);
            this.A4.Name = "A4";
            this.A4.Size = new System.Drawing.Size(100, 23);
            this.A4.TabIndex = 52;
            // 
            // A5
            // 
            this.A5.Location = new System.Drawing.Point(0, 0);
            this.A5.Name = "A5";
            this.A5.Size = new System.Drawing.Size(100, 23);
            this.A5.TabIndex = 51;
            // 
            // A10
            // 
            this.A10.Location = new System.Drawing.Point(0, 0);
            this.A10.Name = "A10";
            this.A10.Size = new System.Drawing.Size(100, 23);
            this.A10.TabIndex = 46;
            // 
            // A9
            // 
            this.A9.Location = new System.Drawing.Point(0, 0);
            this.A9.Name = "A9";
            this.A9.Size = new System.Drawing.Size(100, 23);
            this.A9.TabIndex = 47;
            // 
            // A8
            // 
            this.A8.Location = new System.Drawing.Point(0, 0);
            this.A8.Name = "A8";
            this.A8.Size = new System.Drawing.Size(100, 23);
            this.A8.TabIndex = 48;
            // 
            // A7
            // 
            this.A7.Location = new System.Drawing.Point(0, 0);
            this.A7.Name = "A7";
            this.A7.Size = new System.Drawing.Size(100, 23);
            this.A7.TabIndex = 49;
            // 
            // A6
            // 
            this.A6.Location = new System.Drawing.Point(0, 0);
            this.A6.Name = "A6";
            this.A6.Size = new System.Drawing.Size(100, 23);
            this.A6.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(294, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 39);
            this.label3.TabIndex = 30;
            this.label3.Text = "Restart";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(295, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 37);
            this.label4.TabIndex = 31;
            this.label4.Text = "Restart";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(137, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 39);
            this.label6.TabIndex = 33;
            this.label6.Text = "Restart";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(138, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 37);
            this.label7.TabIndex = 34;
            this.label7.Text = "ГЛАВНОЕ МЕНЮ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(82, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(183, 27);
            this.textBox1.TabIndex = 45;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(583, 624);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.A10);
            this.Controls.Add(this.A9);
            this.Controls.Add(this.A8);
            this.Controls.Add(this.A7);
            this.Controls.Add(this.A6);
            this.Controls.Add(this.A5);
            this.Controls.Add(this.A4);
            this.Controls.Add(this.A3);
            this.Controls.Add(this.A2);
            this.Controls.Add(this.A1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SnakeLengthLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EndGameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label EndGameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SnakeLengthLabel;
        private System.Windows.Forms.Label A1;
        private System.Windows.Forms.Label A2;
        private System.Windows.Forms.Label A3;
        private System.Windows.Forms.Label A4;
        private System.Windows.Forms.Label A5;
        private System.Windows.Forms.Label A10;
        private System.Windows.Forms.Label A9;
        private System.Windows.Forms.Label A8;
        private System.Windows.Forms.Label A7;
        private System.Windows.Forms.Label A6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}

