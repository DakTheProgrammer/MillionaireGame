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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GameMil.PromptFile();
            Question.Text = GameMil.test();
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
