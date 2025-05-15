using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

// Namespace for the project
namespace Ahmesthete_Firewall_Tutor_Project
{
    // Rules form class
    public partial class Rules : Form
    {
        // List for custom rules
        private List<ClassRules> customRulesList = new List<ClassRules>();
        // List for default rules
        private List<ClassRules> defaultRulesList = new List<ClassRules>();

        // Constructor for the Rules form
        public Rules()
        {
            InitializeComponent();
            // Event handler for the SelectedIndexChanged event of the Applied_To_Combo_Box
            Applied_To_Combo_Box.SelectedIndexChanged += new EventHandler(Applied_To_Combo_Box_SelectedIndexChanged);
        }

        // Event handler for clicking on the Home button
        // Opens the Main form and closes the Rules form
        private void Home_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on the Back button
        // Opens the Main form and closes the Rules form
        private void Back_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for the load event of the Rules form
        // Loads the rules from the files into the lists when the form loads
        private void Rules_Load(object sender, EventArgs e)
        {
            LoadRules();
        }

        // Method to load the rules from the files into the lists
        private void LoadRules()
        {
            // Load default rules
            string[] defaultRulesLines = File.ReadAllLines("DefaultRules.txt");
            foreach (string line in defaultRulesLines)
            {
                ClassRules rule = ClassRules.FromString(line);
                if (rule != null)
                {
                    defaultRulesList.Add(rule);
                }
            }

            // Load custom rules
            string[] customRulesLines = File.ReadAllLines("CustomRules.txt");
            foreach (string line in customRulesLines)
            {
                ClassRules rule = ClassRules.FromString(line);
                if (rule != null)
                {
                    customRulesList.Add(rule);
                }
            }
        }

        // Event handler for the SelectedIndexChanged event of the Applied_To_Combo_Box
        // Enables or disables the IP_Address_Box, Port_Box, and Select_Protocol_Combo_Box based on the selected item
        private void Applied_To_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Applied_To_Combo_Box.Text == "PRO")
            {
                IP_Address_Box.Enabled = false;
                Port_Box.Enabled = false;
                Select_Protocol_Combo_Box.Enabled = true;
            }
            else
            {
                IP_Address_Box.Enabled = true;
                Port_Box.Enabled = true;
                Select_Protocol_Combo_Box.Enabled = false;
            }
        }

        // Event handler for the TextChanged event of the Port_Box
        // Currently, it does nothing when the text of the Port_Box is changed
        private void Port_Box_TextChanged(object sender, EventArgs e)
        {

        }

        // Event handler for the TextChanged event of the IP_Address_Box
        // Currently, it does nothing when the text of the IP_Address_Box is changed
        private void IP_Address_Box_TextChanged(object sender, EventArgs e)
        {

        }

        // Event handler for the SelectedIndexChanged event of the Select_Protocol_Combo_Box
        // Currently, it does nothing when the selected item of the Select_Protocol_Combo_Box is changed
        private void Select_Protocol_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Event handler for the SelectedIndexChanged event of the Decision_Combo_Box
        // Currently, it does nothing when the selected item of the Decision_Combo_Box is changed
        private void Decision_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Event handler for clicking on the Save button
        // Creates a new rule based on the inputs, validates the inputs, adds the new rule to the customRulesList, and saves the new rule to CustomRules.txt
        private void Save_Click(object sender, EventArgs e)
        {
            // Assuming you have textboxes or other inputs for these fields
            ClassRules newRule = new ClassRules
            {
                Rule_Num = customRulesList.Count + 1, // Rule number is one more than the current count of rules
                App = Applied_To_Combo_Box.Text,
                IP = IP_Address_Box.Text,
                Protocol = Select_Protocol_Combo_Box.Text,
                Decision = Decision_Combo_Box.Text
            };

            if (newRule.App != "PRO")
            {
                if (int.TryParse(Port_Box.Text, out int port))
                {
                    if (port < 1000 || port > 9999)
                    {
                        MessageBox.Show("Port number must be exactly four digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    newRule.Port = port;
                }
                else
                {
                    MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Validate IP addresses
                var ipPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
                if (!Regex.IsMatch(newRule.IP, ipPattern))
                {
                    MessageBox.Show("Invalid IP address format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            customRulesList.Add(newRule);
            // Save the new rule to CustomRules.txt
            string ruleString;
            if (newRule.App == "PRO")
            {
                ruleString = $"{newRule.Rule_Num} {newRule.App} {newRule.Protocol} {newRule.Decision}";
            }
            else
            {
                ruleString = $"{newRule.Rule_Num} {newRule.App} {newRule.Port} {newRule.IP} {newRule.Decision}";
            }
            File.AppendAllText("CustomRules.txt", ruleString + Environment.NewLine);
        }

        // Event handler for clicking on the View_Rules button
        // Shows the rules from the customRulesList
        private void View_Rules_Click(object sender, EventArgs e)
        {
            string userRules = string.Join("\n", customRulesList.Select(rule => rule.ToString()));
            MessageBox.Show(userRules, "User Rules");
        }

        // Event handler for clicking on the Default_Rules button
        // Shows the rules from the defaultRulesList
        private void Default_Rules_Click(object sender, EventArgs e)
        {
            string defaultRules = string.Join("\n", defaultRulesList);
            MessageBox.Show(defaultRules, "Default Rules");
        }

        // Event handler for clicking on label8
        // Currently, it does nothing when label8 is clicked
        private void label8_Click(object sender, EventArgs e)
        {
            //Empty
        }
    }
}
