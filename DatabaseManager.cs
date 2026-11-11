using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LUMI_Cyber_Nexus
{
    internal class DatabaseManager
    {
        private string connectionString =
            @"Server=LabVM2049939\SQLEXPRESS;
              Database=LumiCyberDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public void SaveTask(CyberTask task)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql =
                    @"INSERT INTO CyberTasks
                    (Title, Description, Reminder)
                    VALUES
                    (@title,@description,@reminder)";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@title",
                    task.Title);

                cmd.Parameters.AddWithValue(
                    "@description",
                    task.Description);

                cmd.Parameters.AddWithValue(
                    "@reminder",
                    task.Reminder);

                cmd.ExecuteNonQuery();
            }
        }
    }
}