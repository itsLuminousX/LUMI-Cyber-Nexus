using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUMI_Cyber_Nexus
{
    internal class CyberTask
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Reminder { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Reminder}";
        }
    }
}