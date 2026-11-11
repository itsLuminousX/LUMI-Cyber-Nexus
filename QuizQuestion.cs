using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUMI_Cyber_Nexus
{
    internal class QuizQuestion
    {
        public string Question { get; set; }

        public string[] Options { get; set; }

        public int CorrectAnswer { get; set; }
    }
}