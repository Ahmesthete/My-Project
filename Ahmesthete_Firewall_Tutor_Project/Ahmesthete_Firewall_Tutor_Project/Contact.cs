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
    // Contact_us form class
    public partial class Contact_us : Form
    {
        // Constructor for the Contact_us form
        public Contact_us()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for clicking on the Back button
        // Opens the Main form and closes the Contact_us form
        private void Back_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for the load event of the Contact_us form
        // Currently, it does nothing when the form is loaded
        private void Contact_us_Load(object sender, EventArgs e)
        {

        }
    }
}
