using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCC_trial_3
{
    public partial class intermediateScreen : Form
    {
        String filename = "";
        public intermediateScreen()
        {
            InitializeComponent();
        }

        private void uSERTYPEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iNTERMEDIATEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nOVICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noviceScreen noviceScreen = new noviceScreen();
            noviceScreen.Show();
            this.Hide();
        }

        private void iNTERMEDIATEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            expertScreen expertScreen = new expertScreen();
            expertScreen.Show();
            this.Hide();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Users/harsh/source/repos/GCC trial 3/Properties/GccCommands.pdf");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearOperation();
        }

        private void cONSOLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomConsole customConsole = new CustomConsole();
            customConsole.ShowDialog();
            
        }



        //***************   HELPER FUNCTIONS    ***************
        public void openFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "C File (.c)|*.c";
            ofd.Title = "Open a File...";

            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                System.IO.StreamReader streamReader = new System.IO.StreamReader(ofd.FileName);
                codingPanel.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        public void saveFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "C file|*.c";
            saveFileDialog1.Title = "Save a C File";
            saveFileDialog1.ShowDialog();


            if (saveFileDialog1.FileName != "")
            {
                filename = saveFileDialog1.FileName;
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog1.FileName);
                streamWriter.Write(codingPanel.Text);
                streamWriter.Close();
            }
        }

        public void exit()
        {
            Application.Exit();
        }

        public void undoOperation()
        {
            codingPanel.Undo();
        }

        public void redoOperation()
        {
            codingPanel.Redo();
        }

        public void cutOperation()
        {
            codingPanel.Cut();
        }

        public void copyOperation()
        {
            codingPanel.Copy();
        }

        public void pasteOperation()
        {
            codingPanel.Paste();
        }

        public void selectAllOperation()
        {
            codingPanel.SelectAll();
        }

        public void clearOperation()
        {
            codingPanel.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoOperation();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoOperation();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutOperation();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyOperation();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteOperation();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectAllOperation();
        }

        private void codingPanel_TextChanged(object sender, EventArgs e)
        {

        }

        /// custom function to execute in a cmd prompt and get the output as a string
        public void runCmd(String command)
        {
            String result = "";


            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            //consoleOp.Text += "\n" + process.StandardOutput.ReadToEnd();
            String op = process.StandardOutput.ReadToEnd();
            String err = process.StandardError.ReadToEnd();
            process.StandardOutput.Close();
            process.StandardError.Close();
            process.Close();

            //consoleOp.Text = process.StandardOutput.ReadToEnd();

            /* Console.WriteLine(process.StandardOutput.ReadToEnd());
             Console.Read();*/

            if (!err.Equals(""))
            {
                op = err;
            }
            else
            {
                op = "Executable file main_" + filename + @" is stored at D:\HCIOPS";
            }

            MessageBox.Show(op);

        }

        private void intermediateScreen_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ErrorsCompiling_Click(object sender, EventArgs e)
        {

        }
    }
}
