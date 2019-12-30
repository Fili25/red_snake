using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Snake
{
    public partial class records : Form
    {
        public records()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MENU f = new MENU();
            f.Show();
        }

        private void records_Load(object sender, EventArgs e)
        {
            if (Program.Theme == "RedBlack")
            {

                label2.ForeColor = Color.Black;
                label2.BackColor = Color.Red;
                this.BackColor = System.Drawing.Color.Black;
                button2.ForeColor = Color.Red;
                button2.BackColor = Color.Black;
                listBox1.ForeColor = Color.Red;
                listBox1.BackColor = Color.Black;


            }
            else
            {
                label2.ForeColor = Color.Green;
                label2.BackColor = Color.White;
                this.BackColor = System.Drawing.Color.White;
                button2.ForeColor = Color.Green;
                button2.BackColor = Color.White;
                listBox1.ForeColor = Color.Green;ыы
                listBox1.BackColor = Color.White;

            }
            int port = 8005; // порт сервера
            string address = "127.0.0.1"; // адрес сервера
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                string message = "Table";
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // получаем ответ
                data = new byte[1024]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                string otv = builder.ToString();
                string[] words = otv.Split(new char[] { '$' });

                foreach (string s in words)
                {
                    listBox1.Items.Add(s);
                }

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
