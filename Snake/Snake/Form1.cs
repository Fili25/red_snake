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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[,] Box;          //Stores all of the pictureboxes on the board
        int snakeXPos;              //X position of snakes head 
        int snakeYPos;              //Y position of snakes head 
        string changeToDirection = "left";
        string direction = "left";
        int snakeLength = 1;
        int[] snakeXPositions;      //Stores all the X positions of each piece of the snake
        int[] snakeYPositions;      //Stores all the Y positions of each piece of the snake
        Random R = new Random();
        int[] foodXPos;
        int[] foodYPos;
        int AmountOfFood = 1;       //Amount of food on screen at a time
        bool rePlaceFood = true;




        private void Form1_Load(object sender, EventArgs e)
        {
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

            }
            //ЦВЕТ РАМКИ
            EndGameLabel.Cursor = Cursors.Hand;
            foodXPos = new int[10];
            foodYPos = new int[10];
            snakeXPositions = new int[100];
            snakeYPositions = new int[100];
            Box = new PictureBox[30, 30]; //30x30 board of pictureboxes


            for (int y = 0; y < 30; y++)        // v Creates the 30x30 board of pictureboxes
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
            snakeXPos = 15; //Start position of snake
            snakeYPos = 15;
            snakeXPositions[1] = 15;
            snakeYPositions[1] = 15;
            newFood(); //Places food
            panel1.SendToBack();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Get arrow key input to move snake
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

        private void newFood() //Places food
        {
            foodNum = 0;

            for (int y = 0; y < 30; y++)                    // v Stores positions of all the food
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

            if (rePlaceFood == false) //rePlacedFood is true when the game is starting or the Amount of food is changed
            {

                for (int i = 0; i <= AmountOfFood-1; i++)   // v Places food
                {
                    Box[foodXPos[i], foodYPos[i]].BackColor = Color.Blue;
                }                                           // ^
                
                foundBox = false;
                while (foundBox == false)                   // v Places 1 food in a random place and only on a box with nothin in
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
                for (int i = 0; i <= AmountOfFood - 1; i++)   // v Places 1 to 10 food depending on the AmountOfFood variable, (e.g. if AmountOfFood is 4 it places 4 food)
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

        private void checkIFOffBoard()  //Checks if the snake is not on the board, if it is the game ends
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
                endGame();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)    //Called every so many milliseconds depending on the interval which is set determined by the length of the snake (to increase difficulty of game, longer snake = faster update)
        {
            SnakeLengthLabel.Text = snakeLength.ToString();

            switch (changeToDirection) //Checks if the snake can move in the direction of the arrow key pressed
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
            switch (direction) //Changes snakes direction
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

            for (int i = 0; i <= 9; i++)    //Checks if the snake has eaten a food
            {
                if (snakeXPos == foodXPos[i] && snakeYPos == foodYPos[i])
                {
                    snakeLength += 1;
                    SnakeLengthLabel.Text = snakeLength.ToString();
                    newFood();                    
                }
            }           

            for (int i = 1; i < 100; i++) //Checks if the snake has collided with itself
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
                    endGame();
                }
            }

            if (snakeLength < 20) //Increases the snakes movement speed depending on its length (shorter timer interval = faster speed)
            {
                timer1.Interval = 500 - snakeLength * 25;
            }
            
            for (int i = 99; i >= 1; i--) // v Makes the snakes body follow the path the head of the snake took
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

            for (int y = 0; y < 30; y++) // v Updates snakes position
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
            timer1.Interval = 500;
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

        private void A1_Click(object sender, EventArgs e)   // v The Amount of food UI, (top left of form)
        {
            A1.ForeColor = Color.Red;
            A1.Font = new Font(A1.Font, FontStyle.Bold);
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 1;
            rePlaceFood = true;
            newFood();
        }

        private void A2_Click(object sender, EventArgs e)
        {
            A2.ForeColor = Color.Red;
            A2.Font = new Font(A2.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 2;
            rePlaceFood = true;
            newFood();
        }

        private void A3_Click(object sender, EventArgs e)
        {
            A3.ForeColor = Color.Red;
            A3.Font = new Font(A3.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 3;
            rePlaceFood = true;
            newFood();
        }

        private void A4_Click(object sender, EventArgs e)
        {
            A4.ForeColor = Color.Red;
            A4.Font = new Font(A4.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 4;
            rePlaceFood = true;
            newFood();
        }

        private void A5_Click(object sender, EventArgs e)
        {
            A5.ForeColor = Color.Red;
            A5.Font = new Font(A5.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 5;
            rePlaceFood = true;
            newFood();
        }

        private void A6_Click(object sender, EventArgs e)
        {
            A6.ForeColor = Color.Red;
            A6.Font = new Font(A6.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 6;
            rePlaceFood = true;
            newFood();
        }

        private void A7_Click(object sender, EventArgs e)
        {
            A7.ForeColor = Color.Red;
            A7.Font = new Font(A7.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 7;
            rePlaceFood = true;
            newFood();
        }

        private void A8_Click(object sender, EventArgs e)
        {
            A8.ForeColor = Color.Red;
            A8.Font = new Font(A8.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 8;
            rePlaceFood = true;
            newFood();
        }

        private void A9_Click(object sender, EventArgs e)
        {
            A9.ForeColor = Color.Red;
            A9.Font = new Font(A9.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A10.ForeColor = Color.Maroon;
            AmountOfFood = 9;
            rePlaceFood = true;
            newFood();
        }

        private void A10_Click(object sender, EventArgs e)
        {
            A10.ForeColor = Color.Red;
            A10.Font = new Font(A10.Font, FontStyle.Bold);
            A1.ForeColor = Color.Maroon;
            A2.ForeColor = Color.Maroon;
            A3.ForeColor = Color.Maroon;
            A4.ForeColor = Color.Maroon;
            A5.ForeColor = Color.Maroon;
            A6.ForeColor = Color.Maroon;
            A7.ForeColor = Color.Maroon;
            A8.ForeColor = Color.Maroon;
            A9.ForeColor = Color.Maroon;
            AmountOfFood = 10;
            rePlaceFood = true;
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
    }
}
