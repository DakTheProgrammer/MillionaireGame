using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace millionaire
{
    class Game
    {
        private string[] questions;
        private string[] ansA;
        private string[] ansB;
        private string[] ansC;
        private string[] ansD;
        private string[] correctAns;
        private int roundIndex;

        private void MakeInput(StreamReader input)
        {
            Random rand = new Random();
            int rannum = 0;
            int i = 0;
            do
            {
                questions[i] = input.ReadLine();
                correctAns[i] = input.ReadLine();

                rannum = rand.Next(1, 5);

                if (rannum == 1)
                {
                    ansA[i] = correctAns[i];
                    ansB[i] = input.ReadLine();
                    ansC[i] = input.ReadLine();
                    ansD[i] = input.ReadLine();
                }
                else if (rannum == 2)
                {
                    ansA[i] = input.ReadLine();
                    ansB[i] = correctAns[i];
                    ansC[i] = input.ReadLine();
                    ansD[i] = input.ReadLine();
                }
                else if (rannum == 3)
                {
                    ansA[i] = input.ReadLine();
                    ansB[i] = input.ReadLine();
                    ansC[i] = correctAns[i];
                    ansD[i] = input.ReadLine();
                }
                else
                {
                    ansA[i] = input.ReadLine();
                    ansB[i] = input.ReadLine();
                    ansC[i] = input.ReadLine();
                    ansD[i] = correctAns[i];
                }

                i++;
            } while (i < 15);
        }

        public Game()
        {
            questions = new string[15];
            ansA = new string[15];
            ansB = new string[15];
            ansC = new string[15];
            ansD = new string[15];

            correctAns = new string[15];

            roundIndex = 0;
        }

        public string test()
        {
            return ansA[0];
        }

        public void incRound()
        {
            roundIndex++;
        }

        public void PromptFile(ref bool bad)
        {
            // create dialog box enabling user to open file
            OpenFileDialog fileChooser = new OpenFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string fileName; // name of file containing data

            // exit event handler if user clicked "Cancel"
            if (result != DialogResult.Cancel && result != DialogResult.Abort)
            {
                // get specified file name
                fileName = fileChooser.FileName;

                // show error if user specified invalid file
                if (fileName == "" || fileName == null)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (File.Exists(fileName))
                {   //open file to StreamReader
                    try
                    {
                        StreamReader textIn = new StreamReader(
                            new FileStream(fileName, FileMode.OpenOrCreate,
                            FileAccess.Read));

                        MakeInput(textIn);
                    }
                    // handle exception if StreamReader is unavailable
                    catch (IOException)
                    {
                        MessageBox.Show("File Error", "File Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // notify user that file does not exist
                    MessageBox.Show(
                   "File does not exist", "File Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else
            {
                bad = true;
            }
        }

        public string Question
        { get { return questions[roundIndex]; } }

        public string A
        { get { return ansA[roundIndex]; } }

        public string B
        { get { return ansB[roundIndex]; } }

        public string C
        { get { return ansC[roundIndex]; } }

        public string D
        { get { return ansD[roundIndex]; } }

        public int Round
        { get { return roundIndex; } }

        public string Answer
        { get{ return correctAns[roundIndex]; } }

    }
}
