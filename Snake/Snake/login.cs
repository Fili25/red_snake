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
    public partial class login : Form

    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            if (Program.Theme == "RedBlack")
            { 

                label1.ForeColor = Color.Red;
                this.BackColor = System.Drawing.Color.Black;
                button1.ForeColor = Color.Red;
                textBox1.ForeColor = Color.Red;


            }
            else
            {
                label1.ForeColor = Color.Green;
                this.BackColor = System.Drawing.Color.White;
                button1.ForeColor = Color.Green;
                textBox1.ForeColor = Color.Green;
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.playername = textBox1.Text;
            Hide();
            MENU f = new MENU();
            f.Show();

        }

    }
}
