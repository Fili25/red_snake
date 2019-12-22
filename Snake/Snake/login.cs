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
                label2.ForeColor = Color.Red;
                this.BackColor = System.Drawing.Color.Black;
                button1.ForeColor = Color.Red;
                button2.ForeColor = Color.Red;
                button3.ForeColor = Color.Red;
                button4.ForeColor = Color.Red;
                textBox1.ForeColor = Color.Red;
                textBox2.ForeColor = Color.Red;
                textBox3.ForeColor = Color.Red;
                textBox4.ForeColor = Color.Red;


            }
            else
            {
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;
                this.BackColor = System.Drawing.Color.White;
                button1.ForeColor = Color.Green;
                button2.ForeColor = Color.Green;
                button3.ForeColor = Color.Green;
                button4.ForeColor = Color.Green;
                textBox1.ForeColor = Color.Green;
                textBox2.ForeColor = Color.Green;
                textBox3.ForeColor = Color.Green;
                textBox4.ForeColor = Color.Green;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MENU f = new MENU();
            f.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible= false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label1.Visible = false;
            label2.Visible = true;

        }
    }
}
