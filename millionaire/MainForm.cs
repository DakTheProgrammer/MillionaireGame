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
        Game GameMil = new Game();
        
        Label[] Rounds;
        
        int safe = 0;

        int counter = 30;

        SoundPlayer StartAudio = new SoundPlayer(Properties.Resources.lets_play);
        SoundPlayer CorAudio = new SoundPlayer(Properties.Resources.correctanswer);
        SoundPlayer InCortAudio = new SoundPlayer(Properties.Resources.wrong_answer);

        private void PlayAgain()
        {
            MainForm NewForm = new MainForm();
            NewForm.Show();
            this.Dispose(false);
        }

        private void correct()
        {
            CorAudio.Play();
            if (GameMil.Round == 14)
            {
                Time.Stop();
                string temp = "CONGRATS YOU WON 1 MILLION DOLLARS!!\nPlay again?";

                DialogResult YorN = MessageBox.Show(temp, "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                Time.Stop();
                MessageBox.Show("That was correct!");
                counter = 30;
                Time.Start();

                InputBox.Text = "";

                safe = GameMil.Round == 0 ? 100 : safe;
                safe = GameMil.Round == 4 ? 1000 : safe;
                safe = GameMil.Round == 9 ? 32000 : safe;

                AnsA.ForeColor = Color.White;
                AnsB.ForeColor = Color.White;
                AnsC.ForeColor = Color.White;
                AnsD.ForeColor = Color.White;

                Rounds[GameMil.Round].BackColor = Color.Black;

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
            InCortAudio.Play();
            Time.Stop();

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

            DialogResult YorN = MessageBox.Show(temp, "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (YorN == DialogResult.Yes)
            {
                PlayAgain();
            }
            else
            {
                Close();
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool check = false;
            GameMil.PromptFile(ref check);

            StartAudio.Play();

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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                char tester = InputBox.Text[0];
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

            temp = "Congrats you won: " + text + "\nPlay again?";



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

        private void Time_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                Time.Stop();
                incorrect();
            }
            
            TimerLabel.Text = counter.ToString();
        }
    }
}
