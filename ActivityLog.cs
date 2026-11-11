using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUMI_Cyber_Nexus
{
    internal class ActivityLog
    {
        public List<string> Logs =
            new List<string>();

        public void AddLog(
            string action)
        {
            Logs.Add(action);
        }
    }
}