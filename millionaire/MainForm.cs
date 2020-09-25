using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace millionaire
{
    public partial class MainForm : Form
    {
        Game GameMil = new Game();
        Label[] Rounds;
        int safe = 0;

        private void correct()
        {
            if (GameMil.Round == 14)
            {
                    
            }
            else
            {
                safe = GameMil.Round == 0 ? 100 : safe;
                safe = GameMil.Round == 4 ? 1000 : safe;
                safe = GameMil.Round == 9 ? 32000 : safe;

                Rounds[GameMil.Round].BackColor = Color.Black;

                AnsA.BackColor = Color.Black;
                AnsB.BackColor = Color.Black;
                AnsC.BackColor = Color.Black;
                AnsD.BackColor = Color.Black;

                GameMil.incRound();
                
                Rounds[GameMil.Round].BackColor = Color.Orange;

                Question.Text = GameMil.Question;

                AnsA.Text = "1: " + GameMil.A;
                AnsB.Text = "2: " + GameMil.B;
                AnsC.Text = "3: " + GameMil.C;
                AnsD.Text = "4: " + GameMil.D;
            }
        }

        private void incorrect()
        {
            AnsA.BackColor = Color.Red;
            AnsB.BackColor = Color.Red;
            AnsC.BackColor = Color.Red;
            AnsD.BackColor = Color.Red;

            if(GameMil.A == GameMil.Answer)
            {
                AnsA.BackColor = Color.Green;
            }
            else if (GameMil.B == GameMil.Answer)
            {
                AnsA.BackColor = Color.Green;
            }
            else if (GameMil.C == GameMil.Answer)
            {
                AnsA.BackColor = Color.Green;
            }
            else
            {
                AnsD.BackColor = Color.Red;
            }

            MessageBox.Show("Oh thats the wrong answer you will be leaving today with: " + safe);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GameMil.PromptFile();

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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            char tester = InputBox.Text[0];

            if(tester >= 49 && tester <= 52)
            {
                int ans = Convert.ToInt32(tester);
                ans -= 48;

                if(ans == 1)
                {
                    if(GameMil.A == GameMil.Answer)
                    {
                        AnsA.BackColor = Color.Green;
                        AnsB.BackColor = Color.Red;
                        AnsC.BackColor = Color.Red;
                        AnsD.BackColor = Color.Red;

                        correct();
                    }
                    else
                    {
                        incorrect();
                    }
                }
                else if(ans == 2)
                {
                    if (GameMil.B == GameMil.Answer)
                    {
                        AnsB.BackColor = Color.Green;
                        AnsA.BackColor = Color.Red;
                        AnsC.BackColor = Color.Red;
                        AnsD.BackColor = Color.Red;

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
                        AnsC.BackColor = Color.Green;
                        AnsB.BackColor = Color.Red;
                        AnsA.BackColor = Color.Red;
                        AnsD.BackColor = Color.Red;

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
                        AnsD.BackColor = Color.Green;
                        AnsB.BackColor = Color.Red;
                        AnsC.BackColor = Color.Red;
                        AnsA.BackColor = Color.Red;

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

        private void fiftyfifty_Click(object sender, EventArgs e)
        {
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
        }

        private void walk_Click(object sender, EventArgs e)
        {
            string text = "";
            string temp;

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

            MessageBox.Show("Congrats you won: " + text);
        }
    }
}
