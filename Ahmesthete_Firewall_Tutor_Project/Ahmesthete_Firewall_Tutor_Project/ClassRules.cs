using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace for the project
namespace Ahmesthete_Firewall_Tutor_Project
{
    // Class for rules
    internal class ClassRules
    {
        // Properties for the rule number, application, port, IP address, protocol, and decision
        public int Rule_Num { get; set; }
        public string App { get; set; }
        public int Port { get; set; }
        public string IP { get; set; }
        public string Protocol { get; set; }
        public string Decision { get; set; }

        // Method to create a ClassRules object from a string
        public static ClassRules FromString(string line)
        {
            var parts = line.Split(' ');
            if (parts.Length < 4)
            {
                return null;
            }

            var rule = new ClassRules();

            // Rule number
            rule.Rule_Num = int.TryParse(parts[0], out int ruleNum) ? ruleNum : 0;

            // App (SRC, DST, PRO)
            rule.App = parts[1];

            // Port or Protocol
            if (rule.App == "PRO")
            {
                rule.Protocol = parts[2];
            }
            else
            {
                rule.Port = int.TryParse(parts[2], out int port) ? port : 0;
            }

            // IP or Decision
            if (rule.App == "PRO")
            {
                rule.Decision = parts[3];
            }
            else
            {
                rule.IP = parts[3];
            }

            // Decision (only for SRC and DST)
            if (parts.Length > 4)
            {
                rule.Decision = parts[4];
            }

            return rule;
        }

        // Method to convert a ClassRules object to a string
        public override string ToString()
        {
            if (App == "PRO")
            {
                return $"{Rule_Num} {App} {Protocol} {Decision}";
            }
            else
            {
                return $"{Rule_Num} {App} {Port} {IP} {Decision}";
            }
        }
    }
}
