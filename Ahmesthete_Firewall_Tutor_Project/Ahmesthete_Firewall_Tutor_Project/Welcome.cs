using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace for the project
namespace Ahmesthete_Firewall_Tutor_Project
{
    // Welcome form class
    public partial class Welcome : Form
    {
        // Constructor for the Welcome form
        public Welcome()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for clicking on pictureBox1
        // Currently, it does nothing when pictureBox1 is clicked
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for clicking on button1
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Main form
            Main mainForm = new Main();

            // Hide the current (Welcome) form
            this.Hide();

            // Show the Main form as a modal dialog box
            mainForm.ShowDialog();

            // Close the current (Welcome) form
            this.Close();
        }

        // Event handler for the load event of the Welcome form
        // Currently, it does nothing when the form is loaded
        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
