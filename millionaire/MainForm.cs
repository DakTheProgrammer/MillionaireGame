﻿/*
 *              Names: Dakota Wilson, Christian Douglas
 *              Date: 28 September 2020
 *              Class: CMPS 4143 C# Programming
 *              File: Game.cs, Millionaire Game
 *              Purpose: Contains the code for the GUI components to allow the user
 *              to play the game Do You Want to Be a Millionaire. It also has some
 *              of the code containing the fuction of the game that allows the user
 *              to play another game, methods for the behavior of the questions if
 *              answered correctly or in correctly. Also code for the function of 
 *              the timer.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace millionaire
{
    public partial class MainForm : Form
    {
        Game GameMil = new Game();   //Creates an object for Game class
        
        Label[] Rounds;             //Array containing the label for each round
        
        int safe = 0;               //Variable to mark the checkpoints in the game

        int counter = 30;           //variable for the Time_Tick method

        SoundPlayer StartAudio = new SoundPlayer(Properties.Resources.lets_play);
        SoundPlayer CorAudio = new SoundPlayer(Properties.Resources.correctanswer);
        SoundPlayer InCortAudio = new SoundPlayer(Properties.Resources.wrong_answer);
        // Gets all of the audio files for the program

        /*
         *          Method Name: PlayAgain
         *          Return: void
         *          Purpose: Allows the user to start a new game
         */
        private void PlayAgain()
        {
            MainForm NewForm = new MainForm();
            NewForm.Show(); 
            this.Dispose(false);    //deletes old form
        }

        /*
         *          Method Name: correct
         *          Return: void
         *          Purpose: Shows the behavior of the question when
         *          the user gets the question correct or if the user 
         *          beats the game.
         */
        private void correct()
        {
            CorAudio.Play();    //plays correct sound
            if (GameMil.Round == 14)
            {
                Time.Stop();    //stops timer when user get a prompt
                string temp = "CONGRATS YOU WON 1 MILLION DOLLARS!!\nPlay again?";

                DialogResult YorN = MessageBox.Show(temp, "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //message box for the new game and when they win

                if (YorN == DialogResult.Yes)
                {
                    PlayAgain();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Time.Stop();    //stops timer when prompted
                MessageBox.Show("That was correct!");   //prompts correct answer
                counter = 30;
                Time.Start(); //restarts timer 

                InputBox.Text = "";

                safe = GameMil.Round == 0 ? 100 : safe;
                safe = GameMil.Round == 4 ? 1000 : safe;
                safe = GameMil.Round == 9 ? 32000 : safe;
                //stores all of the sagehavens

                AnsA.ForeColor = Color.White;
                AnsB.ForeColor = Color.White;
                AnsC.ForeColor = Color.White;
                AnsD.ForeColor = Color.White;
                //resets color of words incase 5050 was used prior

                Rounds[GameMil.Round].BackColor = Color.Black;

                GameMil.incRound();//round incrementing
                
                Rounds[GameMil.Round].BackColor = Color.Orange;
                //highlights new round

                Question.Text = GameMil.Question;

                AnsA.Text = "1: " + GameMil.A;
                AnsB.Text = "2: " + GameMil.B;
                AnsC.Text = "3: " + GameMil.C;
                AnsD.Text = "4: " + GameMil.D;
                //new questions
            }
        }

        /*
         *          Method Name: incorrect
         *          Return: void
         *          Purpose: Shows the behavior of the question
         *          when the user gets the question wrong
         */
        private void incorrect()
        {
            InCortAudio.Play();    //plays incorrect noise
            Time.Stop();    //stops timer on wrong answer

            AnsA.BackColor = Color.Red;
            AnsB.BackColor = Color.Red;
            AnsC.BackColor = Color.Red;
            AnsD.BackColor = Color.Red;
            //shows wrong answer

            AnsA.ForeColor = Color.White;
            AnsB.ForeColor = Color.White;
            AnsC.ForeColor = Color.White;
            AnsD.ForeColor = Color.White;
            //just to make sure all pretty if 5050 used

            //show correct answer
            if (GameMil.A == GameMil.Answer)
            {
                AnsA.BackColor = Color.Green;
            }
            else if (GameMil.B == GameMil.Answer)
            {
                AnsB.BackColor = Color.Green;
            }
            else if (GameMil.C == GameMil.Answer)
            {
                AnsC.BackColor = Color.Green;
            }
            else
            {
                AnsD.BackColor = Color.Green;
            }

            string temp = "Oh thats the wrong answer you will be leaving today with: $" + safe + "\nPlay again?";
            //prompts with amount won and asks to play again

            DialogResult YorN = MessageBox.Show(temp, "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //plays again if user wants
            if (YorN == DialogResult.Yes)
            {
                PlayAgain();
            }
            else
            {
                Close();
            }
        }

        /*
         *          Method Name: MainForm
         *          Purpose: Initializes components
         */
        public MainForm()
        {
            InitializeComponent();
        }

        /*
         *          Method Name: MainForm_Load
         *          Purpose: Event of the form component, on load
         *          the Time variable gets initialized to 1 second 
         *          and is started, the Rounds array gets initialized,
         *          Ans lables get initialized, Rounds background color
         *          changes to orange. Also checks if form needs to be
         *          closed due to file error
         */
        private void MainForm_Load(object sender, EventArgs e)
        {
            bool check = false;
            GameMil.PromptFile(ref check);

            StartAudio.Play();
            //audio call for the start of game

            if (check)
            {
                Close();
            }

            Time = new System.Windows.Forms.Timer();
            Time.Tick += new EventHandler(Time_Tick);
            Time.Interval = 1000; // 1 second
            Time.Start();
            TimerLabel.Text = counter.ToString();

            Rounds = new Label[] { OneHun, TwoHun, ThreeHun, 
                FiveHun, OneK, TwoK, FourK, EightK, SixteenK, 
                ThirTwoK, SixFourK, OneTwenFiK, TwoFiftK, 
                FivHunK, Mil};

            Question.Text = GameMil.Question;

            AnsA.Text = "1: " + GameMil.A;
            AnsB.Text = "2: " + GameMil.B;
            AnsC.Text = "3: " + GameMil.C;
            AnsD.Text = "4: " + GameMil.D;

            Rounds[GameMil.Round].BackColor = Color.Orange;
        }

        /*
         *      Method Name: SubmitButton_Click
         *      Purpose: Button component that submits the user's
         *      answer and checks to see if the answer is correct
         *      or not, also checks exception handeling in case 
         *      the user submits a blank answer.
         */
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //tests if box is empty
            try
            {
                char tester = InputBox.Text[0];
                //checks if valid answer choice
                if (tester >= 49 && tester <= 52)
                {
                    int ans = Convert.ToInt32(tester);
                    ans -= 48;

                    if (ans == 1)
                    {
                        if (GameMil.A == GameMil.Answer)
                        {
                            correct();
                        }
                        else
                        {
                            incorrect();
                        }
                    }
                    else if (ans == 2)
                    {
                        if (GameMil.B == GameMil.Answer)
                        {
                            correct();
                        }
                        else
                        {
                            incorrect();
                        }
                    }
                    else if (ans == 3)
                    {
                        if (GameMil.C == GameMil.Answer)
                        {
                            correct();
                        }
                        else
                        {
                            incorrect();
                        }
                    }
                    else
                    {
                        if (GameMil.D == GameMil.Answer)
                        {
                            correct();
                        }
                        else
                        {
                            incorrect();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not a proper choice try agan!");
                }
            }
            catch
            {
                MessageBox.Show("Not a proper choice try agan!");
            }
        }

        /*
         *      Method Name: fiftyfifty_Click
         *      Purpose: Button component that can be used once, 
         *      eliminates 2 of the answers, leaving the correct
         *      answer and one other answer.
         */
        private void fiftyfifty_Click(object sender, EventArgs e)
        {
            //shows two answers choices with one correct
            if (GameMil.A == GameMil.Answer)
            {
                AnsC.ForeColor = Color.Black;
                AnsD.ForeColor = Color.Black;
            }
            else if (GameMil.B == GameMil.Answer)
            {
                AnsA.ForeColor = Color.Black;
                AnsC.ForeColor = Color.Black;
            }
            else if (GameMil.C == GameMil.Answer)
            {
                AnsA.ForeColor = Color.Black;
                AnsD.ForeColor = Color.Black;
            }
            else
            {
                AnsB.ForeColor = Color.Black;
                AnsC.ForeColor = Color.Black;
            }

            fiftyfifty.Enabled = false;
            fiftyfifty.Visible = false;
            //disasbles button and makes it disapear
        }

        /*
         *      Method Name: walk_Click
         *      Purpose: Button component that allows the user to quit
         *      the game at any point and prints out the total value of
         *      money that the user had won.
         */
        private void walk_Click(object sender, EventArgs e)
        {
            Time.Stop();//stops time when end game

            string text = "";
            string temp;

            //used for display amounts
            if (GameMil.Round == 0)
            {
                temp = "";
                text = "$0";
            }
            else 
            {
                temp = Rounds[GameMil.Round - 1].Text;
            }

            for (int i = 8; i < temp.Length; i++)
            {
                text += temp[i];
            }
            
            temp = "Congrats you won: " + text + "\nPlay again?";


            //message box that shows result and to play again
            DialogResult YorN = MessageBox.Show(temp, "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(YorN == DialogResult.Yes)
            {
                PlayAgain();
            }
            else
            {
                Close();
            }

        }

        /*
         *      Method Name: Time_Tick
         *      Purpose: Method for the timer 
         */
        private void Time_Tick(object sender, EventArgs e)
        {
            //reduces diplay each timer tick
            counter--;
            if (counter == 0)
            {
                Time.Stop();    //used so doesnt go down to -
                incorrect();
            }
            
            TimerLabel.Text = counter.ToString();   //lable with timer
        }
    }
}
