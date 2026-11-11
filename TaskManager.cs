using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUMI_Cyber_Nexus
{
    internal class TaskManager
    {
        public List<CyberTask> Tasks =
            new List<CyberTask>();

        public void AddTask(
            CyberTask task)
        {
            Tasks.Add(task);
        }

        public void DeleteTask(
            CyberTask task)
        {
            Tasks.Remove(task);
        }
    }
}