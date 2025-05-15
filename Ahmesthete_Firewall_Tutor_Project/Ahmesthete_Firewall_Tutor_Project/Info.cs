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
    // Info form class
    public partial class Info : Form
    {
        // Constructor for the Info form
        public Info()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for clicking on the Back button
        // Opens the Main form and closes the Info form
        private void Back_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for the load event of the Info form
        // Currently, it does nothing when the form is loaded
        private void Info_Load(object sender, EventArgs e)
        {

        }
    }
}
