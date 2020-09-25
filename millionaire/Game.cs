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


        Game()
        {
            questions = new string[15];
            ansA = new string[4];
            ansA = new string[4];
            ansA = new string[4];

        }

        public string test()
        {
            return "a";
        }
        public void PromptFile()
        {
            // create dialog box enabling user to open file
            OpenFileDialog fileChooser = new OpenFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string fileName; // name of file containing data

            // exit event handler if user clicked "Cancel"
            if (result != DialogResult.Cancel)
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
            } // end if

        }
    }
}
