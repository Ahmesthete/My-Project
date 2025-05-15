using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace for the project
namespace Ahmesthete_Firewall_Tutor_Project
{
    // Class for packets
    internal class ClassPackets
    {
        // Properties for the source IP address, destination IP address, source port, destination port, protocol, data, and timestamp
        public string Src_IP { get; set; } // Source IP address
        public string Dst_IP { get; set; } // Destination IP address
        public int Src_Port { get; set; } // Source port
        public int Dst_Port { get; set; } // Destination port
        public string Protocol { get; set; } // Protocol
        public string Data { get; set; } // Data
        public DateTime Timestamp { get; set; } // Timestamp
    }
}
