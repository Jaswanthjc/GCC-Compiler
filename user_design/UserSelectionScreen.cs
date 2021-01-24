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
    public partial class UserSelectionScreen : Form
    {
        public UserSelectionScreen()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (noviceRadio.Checked == true)
            {
                noviceScreen noviceScreen = new noviceScreen();
                noviceScreen.Show();
            }
            else if (intermediateRadio.Checked == true)
            {
                intermediateScreen intermediateScreen = new intermediateScreen();
                intermediateScreen.Show();
            }
            else if (expertRadio.Checked == true)
            {
                expertScreen expertScreen = new expertScreen();
                expertScreen.Show();
            }
            this.Hide();

        }
    }
}
