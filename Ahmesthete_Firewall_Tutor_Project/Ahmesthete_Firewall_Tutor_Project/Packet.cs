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
using System.Net;
using System.Text.RegularExpressions;

// Namespace for the project
namespace Ahmesthete_Firewall_Tutor_Project
{
    // Packet form class
    public partial class Packet : Form
    {
        // List for custom rules
        private List<ClassRules> customRulesList = new List<ClassRules>();
        // List for default rules
        private List<ClassRules> defaultRulesList = new List<ClassRules>();

        // Constructor for the Packet form
        public Packet()
        {
            InitializeComponent();
        }

        // Event handler for clicking on the Home button
        // Opens the Main form and closes the Packet form
        private void Home_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for clicking on the Back button
        // Opens the Main form and closes the Packet form
        private void Back_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        // Event handler for the load event of the Packet form
        // Loads the rules from the files into the lists when the form loads
        private void Packet_Load(object sender, EventArgs e)
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

        // Event handlers for the TextChanged events of the SRC_IP_BOX, SRC_PORT_BOX, DST_IP_BOX, DST_PORT_BOX, and DATA_BOX
        // Currently, they do nothing when the text of the boxes is changed
        private void SRC_IP_BOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void SRC_PORT_BOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void DST_IP_BOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void DST_PORT_BOX_TextChanged(object sender, EventArgs e)
        {

        }

        // Event handler for the SelectedIndexChanged event of the PROTOCOL_COMBO_BOX
        // Currently, it does nothing when the selected item of the PROTOCOL_COMBO_BOX is changed
        private void PROTOCOL_COMBO_BOX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DATA_BOX_TextChanged(object sender, EventArgs e)
        {

        }

        // Event handler for clicking on the Check_Packet button
        // Creates a new packet based on the inputs, validates the packet, checks the packet against the rules, and changes the text of the Decision_Label according to the decision
        private void Check_Packet_Click(object sender, EventArgs e)
        {
            // Assuming you have textboxes or other inputs for these fields
            ClassPackets packet = new ClassPackets
            {
                Src_IP = SRC_IP_BOX.Text,
                Dst_IP = DST_IP_BOX.Text,
                Src_Port = int.TryParse(SRC_PORT_BOX.Text, out int srcPort) ? srcPort : 0,
                Dst_Port = int.TryParse(DST_PORT_BOX.Text, out int dstPort) ? dstPort : 0,
                Protocol = PROTOCOL_COMBO_BOX.Text,
                Data = DATA_BOX.Text,
                Timestamp = DateTime.Now
            };

            // Validate the packet
            string errorMessage;
            if (!ValidatePacket(packet, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check the packet against the rules
            string decision = CheckPacketAgainstRules(packet);

            // Change the text of the Decision_Label according to the decision
            Decision_Label.Text = decision;
        }

        // Method to validate the packet
        private bool ValidatePacket(ClassPackets packet, out string errorMessage)
        {
            // Validate IP addresses
            var ipPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            if (!Regex.IsMatch(packet.Src_IP, ipPattern) || !Regex.IsMatch(packet.Dst_IP, ipPattern))
            {
                errorMessage = "Invalid IP address format.";
                return false;
            }
            // Validate ports
            if (packet.Src_Port < 1000 || packet.Src_Port > 9999 || packet.Dst_Port < 1000 || packet.Dst_Port > 9999)
            {
                errorMessage = "Port number must be exactly four digits.";
                return false;
            }

            // Validate other fields...
            if (string.IsNullOrEmpty(packet.Protocol) || string.IsNullOrEmpty(packet.Data))
            {
                errorMessage = "All fields must be filled.";
                return false;
            }

            errorMessage = null;
            return true;
        }

        // Method to check the packet against the rules
        private string CheckPacketAgainstRules(ClassPackets packet)
        {
            // Check the packet against the default rules
            foreach (ClassRules rule in defaultRulesList)
            {
                if (RuleAppliesToPacket(rule, packet))
                {
                    return rule.Decision;
                }
            }

            // Check the packet against the custom rules
            foreach (ClassRules rule in customRulesList)
            {
                if (RuleAppliesToPacket(rule, packet))
                {
                    return rule.Decision;
                }
            }

            // No rule applies
            return "No rule found in both files";
        }

        // Method to check if a rule applies to a packet
        private bool RuleAppliesToPacket(ClassRules rule, ClassPackets packet)
        {
            // Check the conditions of the rule against the packet
            if (rule.IP == packet.Src_IP || rule.IP == packet.Dst_IP)
            {
                return true;
            }
            if (rule.Port == packet.Src_Port || rule.Port == packet.Dst_Port)
            {
                return true;
            }
            if (rule.Protocol == packet.Protocol)
            {
                return true;
            }

            return false;
        }

        // Event handler for clicking on the Decision_Label
        // Currently, it does nothing when the Decision_Label is clicked
        private void Decision_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
