using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            settings f = new settings();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            records f = new records();
            f.Show();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            if (Program.Theme == "RedBlack")
            {
                this.BackColor = System.Drawing.Color.Black;
                button1.BackColor = System.Drawing.Color.Black;
                button1.ForeColor = System.Drawing.Color.Red;
                button2.BackColor = System.Drawing.Color.Black;
                button2.ForeColor = System.Drawing.Color.Red;
                button3.BackColor = System.Drawing.Color.Black;
                button3.ForeColor = System.Drawing.Color.Red;
                label1.BackColor= System.Drawing.Color.Black;
                label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                button1.BackColor = System.Drawing.Color.White;
                button1.ForeColor = System.Drawing.Color.Green;
                button2.BackColor = System.Drawing.Color.White;
                button2.ForeColor = System.Drawing.Color.Green;
                button3.BackColor = System.Drawing.Color.White;
                button3.ForeColor = System.Drawing.Color.Green;
                label1.BackColor = System.Drawing.Color.White;
                label1.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
