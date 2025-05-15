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
    // Main form class
    public partial class Main : Form
    {
        // Constructor for the Main form
        public Main()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for the load event of the Main form
        // Currently, it does nothing when the form is loaded
        private void Main_Load(object sender, EventArgs e)
        {

        }

        // Event handler for clicking on button1
        // Opens the Rules form and closes the Main form
        private void button1_Click(object sender, EventArgs e)
        {
            Rules rulesForm = new Rules();
            this.Hide();
            rulesForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on Enter_Packets button
        // Opens the Packet form and closes the Main form
        private void Enter_Packets_Click(object sender, EventArgs e)
        {
            Packet packetForm = new Packet();
            this.Hide();
            packetForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on Tutorial button
        // Opens the Tutorial form and closes the Main form
        private void Tutorial_Click(object sender, EventArgs e)
        {
            Tutorial tutorialForm = new Tutorial();
            this.Hide();
            tutorialForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on Info button
        // Opens the Info form and closes the Main form
        private void Info_Click(object sender, EventArgs e)
        {
            Info infoForm = new Info();
            this.Hide();
            infoForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on Contact_us button
        // Opens the Contact_us form and closes the Main form
        private void Contact_us_Click(object sender, EventArgs e)
        {
            Contact_us contactForm = new Contact_us();
            this.Hide();
            contactForm.ShowDialog();
            this.Close();
        }
    }
}
