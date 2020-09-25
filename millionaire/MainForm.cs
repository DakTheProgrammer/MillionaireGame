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

        }

        private void fiftyfifty_Click(object sender, EventArgs e)
        {

        }

        private void walk_Click(object sender, EventArgs e)
        {

        }
    }
}
