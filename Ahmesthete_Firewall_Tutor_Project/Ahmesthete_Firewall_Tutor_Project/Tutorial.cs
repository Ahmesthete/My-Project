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
    // Tutorial form class
    public partial class Tutorial : Form
    {
        // Constructor for the Tutorial form
        public Tutorial()
        {
            InitializeComponent();
        }

        // Event handler for clicking on the Back button
        // Opens the Main form and closes the Tutorial form
        private void Back_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on the Tutorial_Add_Rules button
        // Shows a message box with information about adding rules
        private void Tutorial_Add_Rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("When you click the 'Add Rules' button, you will be taken to a new form. In this form, you can add rules for network traffic. The form will have fields for 'Applied to', 'Port', 'IP Address', 'Select protocol', and 'Select decision'. After entering these details, you can click on the 'Save' button to save the new rule to 'CustomRules.txt'. You can also view the rules from the customRulesList and defaultRulesList by clicking on the 'View Rules' and 'Default Rules' buttons respectively. Also by clicking on the 'Back' and 'Home' buttons you will be taken back to the Main Form.");
        }

        // Event handler for clicking on the Tutorial_Enter_Packets button
        // Shows a message box with information about entering packets
        private void Tutorial_Enter_Packets_Click(object sender, EventArgs e)
        {
            MessageBox.Show("When you click the 'Enter Packets' button, you will be taken to a new form. In this form, you can enter packet details such as 'Source IP Address', 'Source Port', 'Destination IP Address', 'Destination Port', 'Protocol', and 'Data'. After entering these details, the decision (allowed or denied) will be displayed.");
        }

        // Event handler for clicking on the Tutorial_Tutorial button
        // Shows a message box with information about the tutorial
        private void Tutorial_Tutorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On clicking the 'Tutorial' button, the tutorial form will be displayed where you can learn more about the Firewall Tutor and its functionality.");
        }

        // Event handler for clicking on the Tutorial_Info button
        // Shows a message box with information about the Firewall Tutor application
        private void Tutorial_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On clicking the 'Info' button, information about the Firewall Tutor application will be displayed.");
        }

        // Event handler for clicking on the Tutorial_Contact_us button
        // Shows a message box with information about contacting the developers of the Firewall Tutor
        private void Tutorial_Contact_us_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On clicking the 'Contact Us' button, a new form named 'Contact Us' will be displayed. In this form, you will find the names and contact information of the developers of this Firewall Tutor. You can contact them via phone numbers or email addresses.");
        }

        // Event handler for the load event of the Tutorial form
        // Currently, it does nothing when the form is loaded
        private void Tutorial_Load(object sender, EventArgs e)
        {

        }
    }
}
