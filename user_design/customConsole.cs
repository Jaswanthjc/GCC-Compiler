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
    public partial class CustomConsole : Form
    {
        public CustomConsole()
        {
            InitializeComponent();
        }

        String filename = "";
        String filepath = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!commandWindow.Text.Equals(""))
            {
                String command = commandWindow.Text;
                String output = "";
                String error = "";

                // Initialize powershell for gcc command execution
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                // write commands from the textbox to powershell
                process.StandardInput.WriteLine(command);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                
                // read the cmd prompt
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                
                // close the streams
                process.StandardOutput.Close();
                process.StandardError.Close();
                process.Close();

                // show the outputs
                outputWindow.Text = output;
                errorWindow.Text = error;

            }
        }


        
    }
}
