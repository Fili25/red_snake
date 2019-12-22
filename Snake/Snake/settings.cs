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

    
    public partial class settings : Form
    {
        
        
        public settings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MENU f = new MENU();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            login f = new login();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Theme = "RedBlack";
            this.BackColor = System.Drawing.Color.Black;
            button1.BackColor = System.Drawing.Color.Black;
            button1.ForeColor = System.Drawing.Color.Red;
            button2.BackColor = System.Drawing.Color.Black;
            button2.ForeColor = System.Drawing.Color.Red;
            button3.BackColor = System.Drawing.Color.Black;
            button3.ForeColor = System.Drawing.Color.Red;
            button4.BackColor = System.Drawing.Color.Black;
            button4.ForeColor = System.Drawing.Color.Red;
            label1.BackColor = System.Drawing.Color.Black;
            label1.ForeColor = System.Drawing.Color.Red;
            label2.BackColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.Theme = "WhiteBlue";
            this.BackColor = System.Drawing.Color.White;
            button1.BackColor = System.Drawing.Color.White;
            button1.ForeColor = System.Drawing.Color.Green;
            button2.BackColor = System.Drawing.Color.White;
            button2.ForeColor = System.Drawing.Color.Green;
            button3.BackColor = System.Drawing.Color.White;
            button3.ForeColor = System.Drawing.Color.Green;
            button4.BackColor = System.Drawing.Color.White;
            button4.ForeColor = System.Drawing.Color.Green;
            label1.BackColor = System.Drawing.Color.White;
            label1.ForeColor = System.Drawing.Color.Green;
            label2.BackColor = System.Drawing.Color.White;
            label2.ForeColor = System.Drawing.Color.Green;

        }

        private void settings_Load(object sender, EventArgs e)
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
                button4.BackColor = System.Drawing.Color.Black;
                button4.ForeColor = System.Drawing.Color.Red;
                label1.BackColor = System.Drawing.Color.Black;
                label1.ForeColor = System.Drawing.Color.Red;
                label2.BackColor = System.Drawing.Color.Black;
                label2.ForeColor = System.Drawing.Color.Red;
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
                button4.BackColor = System.Drawing.Color.White;
                button4.ForeColor = System.Drawing.Color.Green;
                label1.BackColor = System.Drawing.Color.White;
                label1.ForeColor = System.Drawing.Color.Green;
                label2.BackColor = System.Drawing.Color.White;
                label2.ForeColor = System.Drawing.Color.Green;
                
            }
        }
    }
}
