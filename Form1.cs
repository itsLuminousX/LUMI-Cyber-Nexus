using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LUMI_Cyber_Nexus
{
    public partial class Form1 : Form
    {
        private ChatResponses chatResponses =
            new ChatResponses();

        private RandomResponses randomResponses =
            new RandomResponses();

        private MemoryManager memory =
            new MemoryManager();

        private SentimentAnalyzer sentiment =
            new SentimentAnalyzer();

        private TaskManager taskManager =
            new TaskManager();

        private QuizManager quizManager =
            new QuizManager();

        private DatabaseManager database =
            new DatabaseManager();

      

        private int currentQuestion = 0;

        private int score = 0;

        public Form1()
        {
            InitializeComponent();

            rtbChat.AppendText(
                "LUMI: Welcome to Lumi Cyber Nexus!" +
                Environment.NewLine +
                "Ask me about cybersecurity." +
                Environment.NewLine +
                Environment.NewLine);

            LoadQuestion();
        }

        private void Form1_Load_1(
            object sender,
            EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtUserInput_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void label2_Click(
            object sender,
            EventArgs e)
        {
        }

        private void label3_Click(
            object sender,
            EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(
            object sender,
            CancelEventArgs e)
        {
        }

        private void btnSend_Click(
            object sender,
            EventArgs e)
        {
            string question =
                txtUserInput.Text
                .ToLower()
                .Trim();

            if (string.IsNullOrEmpty(question))
                return;

            rtbChat.AppendText(
                "You: " +
                question +
                Environment.NewLine);

            AsyncLogger.Log(
                "User",
                question);

            string response = "";

            if (question.Contains("my favourite topic is"))
            {
                memory.FavouriteTopic =
                    question.Replace(
                    "my favourite topic is",
                    "")
                    .Trim();

                response =
                    "I will remember that your favourite topic is " +
                    memory.FavouriteTopic + ".";
            }
            else if (question.Contains(
                "what is my favourite topic"))
            {
                response =
                    "Your favourite topic is " +
                    memory.FavouriteTopic + ".";
            }
            else if (question.Contains(
                "phishing tip"))
            {
                response =
                    randomResponses
                    .GetRandomPhishingTip();

                memory.LastTopic =
                    "phishing";
            }
            else if (question.Contains(
                "tell me more"))
            {
                switch (memory.LastTopic)
                {
                    case "phishing":

                        response =
                            "Phishing attacks often use fake websites and emails.";

                        break;

                    case "ransomware":

                        response =
                            "Ransomware encrypts files and demands payment.";

                        break;

                    default:

                        response =
                            "Please ask me about a cybersecurity topic first.";

                        break;
                }
            }
            else
            {
                string mood =
                    sentiment.Analyze(question);

                if (mood == "positive")
                {
                    response =
                        "That's wonderful to hear!";
                }
                else if (mood == "negative")
                {
                    response =
                        "I'm sorry you're feeling that way.";
                }
            }

            if (string.IsNullOrEmpty(response))
            {
                foreach (var item in
                    chatResponses.Responses)
                {
                    if (question.Contains(item.Key))
                    {
                        response =
                            item.Value;

                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(response))
            {
                response =
                    "I don't understand. Try asking about cybersecurity topics.";
            }

            rtbChat.AppendText(
                "LUMI: " +
                response +
                Environment.NewLine +
                Environment.NewLine);

            AsyncLogger.Log(
                "LUMI",
                response);

            txtUserInput.Clear();
        }

        private void btnAddTask_Click(
            object sender,
            EventArgs e)
        {
            CyberTask task =
                new CyberTask()
                {
                    Title =
                        txtTaskTitle.Text,

                    Description =
                        txtTaskDescription.Text,

                    Reminder =
                        txtReminder.Text
                };

            taskManager.AddTask(task);

            database.SaveTask(task);

            lstTasks.Items.Add(task);

            MessageBox.Show(
                "Task added successfully!");

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            txtReminder.Clear();
        }

        private void btnDeleteTask_Click(
            object sender,
            EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                lstTasks.Items.Remove(
                    lstTasks.SelectedItem);

                MessageBox.Show(
                    "Task deleted.");
            }
        }

        private void LoadQuestion()
        {
            if (currentQuestion >=
                quizManager.Questions.Count)
            {
                MessageBox.Show(
                    "Quiz Complete!\nScore: " +
                    score);

                return;
            }

            QuizQuestion q =
                quizManager.Questions[currentQuestion];

            lblQuestion.Text =
                q.Question;

            btnA.Text =
                q.Options[0];

            btnB.Text =
                q.Options[1];

            btnC.Text =
                q.Options[2];

            btnD.Text =
                q.Options[3];
        }

        private void CheckAnswer(
            int selected)
        {
            if (selected ==
                quizManager.Questions[currentQuestion]
                .CorrectAnswer)
            {
                score++;

                MessageBox.Show(
                    "Correct!");
            }
            else
            {
                MessageBox.Show(
                    "Incorrect!");
            }

            currentQuestion++;

            lblScore.Text =
                "Score: " + score;

            LoadQuestion();
        }

        private void btnA_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(0);
        }

        private void btnB_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(1);
        }

        private void btnC_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(2);
        }

        private void btnD_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(3);
        }
        private void btnDeleteTask_Click_1(
        object sender,
        EventArgs e)
        {
            btnDeleteTask_Click(sender, e);
        }

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(0);
        }

        private void button3_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(1);
        }

        private void button4_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(2);
        }

        private void button5_Click(
            object sender,
            EventArgs e)
        {
            CheckAnswer(3);
        }
        private ActivityLog activity =
        new ActivityLog();
    }
}


