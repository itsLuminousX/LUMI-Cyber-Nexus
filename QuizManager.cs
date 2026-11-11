using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LUMI_Cyber_Nexus
{
    internal class QuizManager
    {
        public List<QuizQuestion> Questions =
            new List<QuizQuestion>()
            {
                new QuizQuestion()
                {
                    Question = "What is phishing?",

                    Options = new string[]
                    {
                        "A scam email",
                        "A firewall",
                        "A VPN",
                        "Antivirus"
                    },

                    CorrectAnswer = 0
                },

                new QuizQuestion()
                {
                    Question = "What does a VPN do?",

                    Options = new string[]
                    {
                        "Deletes files",
                        "Encrypts internet traffic",
                        "Creates passwords",
                        "Blocks email"
                    },

                    CorrectAnswer = 1
                },

                new QuizQuestion()
                {
                    Question = "What should a strong password contain?",

                    Options = new string[]
                    {
                        "Only letters",
                        "Only numbers",
                        "Letters, numbers and symbols",
                        "Your name"
                    },

                    CorrectAnswer = 2
                }
            };
    }
}