/*
 *              Names: Dakota Wilson, Christian Douglas
 *              Date: 28 September 2020
 *              Class: CMPS 4143 C# Programming
 *              File: Game.cs, Millionaire Game
 *              Purpose: Moves the answer choices around so the 
 *              user doesn't choose the same, traverses the user
 *              through the rounds, prompts the user for an infile
 *              and prints the questions and the answers to the 
 *              labels.
*/
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

        /*
         *      Method Name: MakeInput
         *      Purpose: Randomizes the answer positions for each
         *      question and checks to see which is the correct 
         *      answer
         */
        private void MakeInput(StreamReader input)
        {
            Random rand = new Random(); //gets a ranom seed generator
            int rannum = 0;
            int i = 0;

            //DO WHILE LOOP
            do
            {
                questions[i] = input.ReadLine();//gets question
                correctAns[i] = input.ReadLine();//places correct answer

                rannum = rand.Next(1, 5);//radom num 1-4

                //randomizes input
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

        /*
         *      Method Name: Game
         *      Purpose: makes all defualts with default
         *      constructor
         */
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

        /*
         *      Method Name: incRound
         *      Purpose: Increments the rounds.
         */
        public void incRound()
        {
            roundIndex++;
        }

        /*
         *      Method Name: PromptFile
         *      Purpose: Creates a dialog box for the user to be able
         *      to choose a text file, if the user doesn't choose an
         *      input file or puts an invalid file, a message box
         *      pops up informing the user that they did not choose a
         *      valid file.
         */
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
                bad = true; //bool return to check if form needs 
                            //closed for error handling
            }
        }

        /*
         *      Method Name: Question
         *      Purpose: gets question at round
         */
        public string Question
        { get { return questions[roundIndex]; } }

        /*
         *      Method Name: A
         *      Purpose: gets answer choice 1
         */
        public string A
        { get { return ansA[roundIndex]; } }

        /*
         *      Method Name: B
         *      Purpose: gets answer choice 2
         */
        public string B
        { get { return ansB[roundIndex]; } }

        /*
         *      Method Name: C
         *      Purpose: gets answer choice 3
         */
        public string C
        { get { return ansC[roundIndex]; } }

        /*
         *      Method Name: D
         *      Purpose: gets answer choice 4
         */
        public string D
        { get { return ansD[roundIndex]; } }

        /*
         *      Method Name: Round
         *      Purpose: gets round game is on
         */
        public int Round
        { get { return roundIndex; } }

        /*
         *      Method Name: Answer
         *      Purpose: gets answe to round
         */
        public string Answer
        { get{ return correctAns[roundIndex]; } }

    }
}
