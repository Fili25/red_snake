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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[,] Box;          //Хранит все PictureBox на поле
        int snakeXPos;              //Позиция головы змейки по оси X 
        int snakeYPos;              //Позиция головы змейки по оси Y
        string changeToDirection = "left";
        string direction = "left";
        int snakeLength = 1;
        int[] snakeXPositions;      //Хранит все позиции каждой части змеи по оси X 
        int[] snakeYPositions;      //Хранит все позиции каждой части змеи по оси Y
        Random R = new Random();
        int[] foodXPos;
        int[] foodYPos;
        int AmountOfFood = 1;       //Колличество еды на экране в одно время
        bool rePlaceFood = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.playername;
            if (Program.Theme == "RedBlack")
                {
                panel1.BackColor = Color.Red;
                this.BackColor = System.Drawing.Color.Black;
                label3.BackColor = System.Drawing.Color.Red;
                label3.ForeColor = System.Drawing.Color.Red;
                label6.BackColor = System.Drawing.Color.Red;
                label6.ForeColor = System.Drawing.Color.Red;
                label7.BackColor = System.Drawing.Color.Black;
                label7.ForeColor = System.Drawing.Color.Red;
                label4.BackColor = System.Drawing.Color.Black;
                label4.ForeColor = System.Drawing.Color.Red;
                label1.BackColor = System.Drawing.Color.Black;
                label1.ForeColor = System.Drawing.Color.Red;
                SnakeLengthLabel.BackColor = System.Drawing.Color.Black;
                SnakeLengthLabel.ForeColor = System.Drawing.Color.Red;
                textBox1.ForeColor= System.Drawing.Color.Red;
                textBox1.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                panel1.BackColor = Color.Green;
                this.BackColor = System.Drawing.Color.White;
                label3.BackColor= System.Drawing.Color.Green;
                label3.ForeColor = System.Drawing.Color.Green;
                label6.BackColor = System.Drawing.Color.Green;
                label6.ForeColor = System.Drawing.Color.Green;
                label7.BackColor = System.Drawing.Color.White;
                label7.ForeColor = System.Drawing.Color.Green;
                label4.BackColor = System.Drawing.Color.White;
                label4.ForeColor = System.Drawing.Color.Green;
                label1.BackColor = System.Drawing.Color.White;
                label1.ForeColor = System.Drawing.Color.Green;
                SnakeLengthLabel.BackColor = System.Drawing.Color.White;
                SnakeLengthLabel.ForeColor = System.Drawing.Color.Green;
                textBox1.ForeColor = System.Drawing.Color.Green;
                textBox1.BackColor = System.Drawing.Color.White;

            }
            //ЦВЕТ РАМКИ
            EndGameLabel.Cursor = Cursors.Hand;
            foodXPos = new int[10];
            foodYPos = new int[10];
            snakeXPositions = new int[100];
            snakeYPositions = new int[100];
            Box = new PictureBox[30, 30]; //30x30 поле picturebox


            for (int y = 0; y < 30; y++)        // Создает поле 30x30 pictureboxes
            {
                for (int x = 0; x < 30; x++)
                {
                    Box[x, y] = new PictureBox();
                    Box[x, y].Left = 50 + x * 16;
                    Box[x, y].Top = 100 + y * 16;
                    Box[x, y].Width = 17;
                    Box[x, y].Height = 17;
                    if (Program.Theme == "RedBlack")
                        Box[x, y].BackColor = Color.Black;
                    else
                        Box[x, y].BackColor = Color.White;
                    Controls.Add(Box[x, y]);
                }
            }                                   // ^
            if (Program.Theme == "RedBlack")
                Box[15, 15].BackColor = Color.Red;
            else
                Box[15, 15].BackColor = Color.Green;
            snakeXPos = 15; //Начальная позиция змеи
            snakeYPos = 15;
            snakeXPositions[1] = 15;
            snakeYPositions[1] = 15;
            newFood(); //Размещает еду
            panel1.SendToBack();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Получить стрелочный ввод управелния змеи
        {
            switch (keyData)
            {
                case Keys.Left:
                    changeToDirection = "left";
                    break;
                case Keys.Right:
                    changeToDirection = "right";
                    break;
                case Keys.Up:
                    changeToDirection = "up";
                    break;
                case Keys.Down:
                    changeToDirection = "down";
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        bool foundBox = false;
        int foodNum = 1;

        private void newFood() //Размещение еды
        {
            foodNum = 0;

            for (int y = 0; y < 30; y++)                    //Установка позиций всей еды
            {
                for (int x = 0; x < 30; x++)
                {
                    if (Box[x, y].BackColor == Color.Blue)
                    {
                        foodXPos[foodNum] = x;
                        foodYPos[foodNum] = y;
                        if (Program.Theme == "RedBlack")
                        {
                            foodNum += 1;
                            Box[x, y].BackColor = Color.Black;
                            Box[x, y].BackColor = Color.Black;
                        }
                        else
                        {
                            foodNum += 1;
                            Box[x, y].BackColor = Color.White;
                            Box[x, y].BackColor = Color.White;
                        }
                    }
                }
            }                                               // ^

            if (rePlaceFood == false) //rePlacedFood имеет значение true, когда игра запускается или количество еды меняется
            {

                for (int i = 0; i <= AmountOfFood-1; i++)   // Размещение еды
                {
                    Box[foodXPos[i], foodYPos[i]].BackColor = Color.Blue;
                }                                           // ^
                
                foundBox = false;
                while (foundBox == false)                   // v Размещает 1 еду в случайном месте и только на поле без всего
                {
                    foodXPos[AmountOfFood-  1] = R.Next(0, 30);
                    foodYPos[AmountOfFood - 1] = R.Next(0, 30);
                    if (Program.Theme == "RedBlack")
                        if (Box[foodXPos[AmountOfFood - 1], foodYPos[AmountOfFood - 1]].BackColor == Color.Black)
                        {
                            Box[foodXPos[AmountOfFood - 1], foodYPos[AmountOfFood - 1]].BackColor = Color.Blue;
                            foundBox = true;
                        }
                        else
                        {
                            foodXPos[AmountOfFood - 1] = R.Next(0, 30);
                            foodYPos[AmountOfFood - 1] = R.Next(0, 30);
                        }
                    else
                        if (Box[foodXPos[AmountOfFood - 1], foodYPos[AmountOfFood - 1]].BackColor == Color.White)
                    {
                        Box[foodXPos[AmountOfFood - 1], foodYPos[AmountOfFood - 1]].BackColor = Color.Blue;
                        foundBox = true;
                    }
                    else
                    {
                        foodXPos[AmountOfFood - 1] = R.Next(0, 30);
                        foodYPos[AmountOfFood - 1] = R.Next(0, 30);
                    }

                }                                           // ^
            }
            else
            {
                rePlaceFood = false;
                for (int i = 0; i <= AmountOfFood - 1; i++)   // v Размещает от 1 до 10 еды в зависимости от переменной AmountOfFood (например, если AmountOfFood равен 4, в нем размещается 4 еды)
                {
                    foundBox = false;
                    while (foundBox == false)
                    {
                        foundBox = false;

                        foodXPos[i] = R.Next(0, 30);
                        foodYPos[i] = R.Next(0, 30);
                        if (Program.Theme == "RedBlack")
                            if (Box[foodXPos[i], foodYPos[i]].BackColor == Color.Black)
                            {
                                Box[foodXPos[i], foodYPos[i]].BackColor = Color.Blue;
                                foundBox = true;
                            }
                            else
                            {
                                foodXPos[i] = R.Next(0, 30);
                                foodYPos[i] = R.Next(0, 30);
                            }
                        else
                            if (Box[foodXPos[i], foodYPos[i]].BackColor == Color.White)
                        {
                            Box[foodXPos[i], foodYPos[i]].BackColor = Color.Blue;
                            foundBox = true;
                        }
                        else
                        {
                            foodXPos[i] = R.Next(0, 30);
                            foodYPos[i] = R.Next(0, 30);
                        }
                    }
                }                                           // ^
            }
        }

        private void checkIFOffBoard()  //Проверяет, нет ли змеи на поле, заканчивается если ее нет
        {
            if (snakeXPos < 0 || snakeXPos > 29 || snakeYPos < 0 || snakeYPos > 29)
                {
                    if (Program.Theme == "RedBlack")
                         { 
                            EndGameLabel.BackColor = Color.Black;
                            EndGameLabel.ForeColor = Color.Red;
                         }
                    else
                         {
                            EndGameLabel.BackColor = Color.Green;
                            EndGameLabel.ForeColor = Color.White;
                         }
                EndGameLabel.Text = "You Lost!" + Environment.NewLine + Environment.NewLine + "The snake went off the board" + Environment.NewLine + Environment.NewLine + "Click to play again";
                //конец
                send(Convert.ToString(snakeLength));
                endGame();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)    //Вызывается каждую миллисекунду в зависимости от установленного интервала, определяемого длиной змеи (для увеличения сложности игры. длинная змея = более быстрое обновление)
        {
            SnakeLengthLabel.Text = snakeLength.ToString();

            switch (changeToDirection) //Проверяет, может ли змея двигаться в направлении нажатой клавиши со стрелкой
            {
                case "left":
                    if (direction != "right")
                    {
                        direction = "left";
                    }
                    break;
                case "right":
                    if (direction != "left")
                    {
                        direction = "right";
                    }
                    break;
                case "up":
                    if (direction != "down")
                    {
                        direction = "up";
                    }
                    break;
                case "down":
                    if (direction != "up")
                    {
                        direction = "down";
                    }
                    break;
            }
            switch (direction) //меняет напрвление змеи
            {
                case "left":
                    snakeXPos -= 1;
                    checkIFOffBoard();
                    if (Program.Theme == "RedBlack")
                        Box[snakeXPos, snakeYPos].BackColor = Color.Red;
                    else
                        Box[snakeXPos, snakeYPos].BackColor = Color.Green;

                    break;
                case "right":
                    snakeXPos += 1;
                    checkIFOffBoard();
                    if (Program.Theme == "RedBlack")
                        Box[snakeXPos, snakeYPos].BackColor = Color.Red;
                    else
                        Box[snakeXPos, snakeYPos].BackColor = Color.Green;
                    break;
                case "up":
                    snakeYPos -= 1;
                    checkIFOffBoard();
                    if (Program.Theme == "RedBlack")
                        Box[snakeXPos, snakeYPos].BackColor = Color.Red;
                    else
                        Box[snakeXPos, snakeYPos].BackColor = Color.Green;
                    break;
                case "down":
                    snakeYPos += 1; 
                    checkIFOffBoard();
                    if (Program.Theme == "RedBlack")
                        Box[snakeXPos, snakeYPos].BackColor = Color.Red;
                    else
                        Box[snakeXPos, snakeYPos].BackColor = Color.Green;
                    break;
            }

            for (int i = 0; i <= 9; i++)    //проверяет съела ли змея еду
            {
                if (snakeXPos == foodXPos[i] && snakeYPos == foodYPos[i])
                {
                    snakeLength += 1;
                    SnakeLengthLabel.Text = snakeLength.ToString();
                    newFood();                    
                }
            }           

            for (int i = 1; i < 100; i++) //Проверяет, столкнулась ли змея с собой
            {
                if (snakeXPos == snakeXPositions[i] && snakeYPos == snakeYPositions[i])
                {
                    if (Program.Theme == "RedBlack")
                    {
                        EndGameLabel.BackColor = Color.Black;
                        EndGameLabel.ForeColor = Color.Red;
                    }
                    else
                    {
                        EndGameLabel.BackColor = Color.White;
                        EndGameLabel.ForeColor = Color.Green;
                    }
                    EndGameLabel.Text = "You Lost!" + Environment.NewLine + Environment.NewLine + "The snake collided with itself" + Environment.NewLine + Environment.NewLine + "Click to play again";
                    //конец
                    send(Convert.ToString(snakeLength));
                    endGame();
                }
            }

            if (snakeLength < 60) //Увеличивает скорость движения змей в зависимости от ее длины (более короткий интервал таймера = более высокая скорость)
            {
                timer1.Interval = 300-snakeLength*5;
            }
            
            for (int i = 99; i >= 1; i--) // vЗаставляет тело змеи следовать по пути, по которому шла голова змеи
            {
                if (i < snakeLength)
                {
                    snakeXPositions[i + 1] = snakeXPositions[i];
                    snakeYPositions[i + 1] = snakeYPositions[i];
                }
                else if (i > snakeLength)
                {
                    snakeXPositions[i] = -1;
                    snakeYPositions[i] = 0;
                }
            }                           // ^

            snakeXPositions[1] = snakeXPos;            
            snakeYPositions[1] = snakeYPos;

            for (int y = 0; y < 30; y++) // vОбновляет позицию змеи
            {
                for (int x = 0; x < 30; x++)
                {   
                    if (Box[x, y].BackColor != Color.Blue)
                    {
                        if (Program.Theme == "RedBlack")
                            Box[x, y].BackColor = Color.Black;
                        else
                            Box[x, y].BackColor = Color.White;  
                    }


                        
                }
            }

            for (int i = 1; i < 100; i++)
            {
                if (snakeXPositions[i] != -1)
                {
                    
                    if (Program.Theme == "RedBlack")
                        Box[snakeXPositions[i], snakeYPositions[i]].BackColor = Color.Red;
                    else
                        Box[snakeXPositions[i], snakeYPositions[i]].BackColor = Color.Green;
                }

            }                           // ^
        }

        private void endGame()
        {
            snakeXPos = 15;
            snakeYPos = 15;            
            EndGameLabel.Visible = true;
            timer1.Stop();
        }

        private void EndGameLabel_Click(object sender, EventArgs e)
        {
            EndGameLabel.Visible = false;
            ResetGame();
        }

        private void ResetGame()
        {
            timer1.Interval = 300;
            timer1.Start();
            rePlaceFood = true;

            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    if (Program.Theme == "RedBlack")
                        Box[x, y].BackColor = Color.Black;
                    else
                        Box[x, y].BackColor = Color.White;
                }
            }

            for (int i = 1; i < 100; i++)
            {
                snakeXPositions[i] = -1;
                snakeYPositions[i] = -1;
            }

            snakeLength = 1;

            if (Program.Theme == "RedBlack")
                Box[15, 15].BackColor = Color.Red;
            else
                Box[15, 15].BackColor = Color.Green;
            snakeXPos = 15;
            snakeYPos = 15;
            direction = "left";
            changeToDirection = "left";
            snakeXPositions[1] = 15;
            snakeYPositions[1] = 15;
            newFood();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Hide();
            MENU f = new MENU();
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        static void send(string score)
        {
            // адрес и порт сервера, к которому будем подключаться
            int port = 8005; // порт сервера
            string address = "127.0.0.1"; // адрес сервера
            
                
                    try
                    {
                        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        // подключаемся к удаленному хосту
                        socket.Connect(ipPoint);
                        string message = "GamerName=" + Program.playername + "Score=" + score;
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
                        //Console.WriteLine("ответ сервера: " + builder.ToString());

                        // закрываем сокет
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    // Console.Read();
                
            

        }

    }
}
