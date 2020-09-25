using System;
using System.IO;
using System.IO.Stream;
using System.Windows.Forms;

        
        // create dialog box enabling user to open file
        SaveFileDialog fileChooser = new OpenFileDialog();
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
                MessageBox.Show(inputTextBox.Text +
               " does not exist", "File Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // end if



        string stringText;
        int numAns;
        //check if more data
        if (textIn.Peek() != -1)
        {  
           //get line and the 2 pieces of data on the line
           string row = textIn.ReadLine();
           string [] columns = row.Split('|');
           stringText = columns[0];
           numAns = Convert.ToInt32(columns[1]);
        }
        else
        {
            textIn.Close();
        }

    }
}