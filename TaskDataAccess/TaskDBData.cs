using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TaskModel;

namespace TaskDataAccess
{
    public class TaskDBData
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS02; Initial Catalog=Tasks; Integrated Security=True; TrustServerCertificate=True;";

        public List<TaskItem> GetAll()
        {
            List<TaskItem> tasks = new List<TaskItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Name, Status FROM dbo.Tasks";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
            return tasks;
        }

        public void Add(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO dbo.Tasks (Name, Status) VALUES (@Name, 'Not Done')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.ExecuteNonQuery();
            }
        }

        public bool Edit(int id, string newName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE dbo.Tasks SET Name = @Name WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM dbo.Tasks WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Mark(int id, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Safe check for current status
                string checkQuery = "SELECT Status FROM dbo.Tasks WHERE Id = @Id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Id", id);
                
                object result = checkCmd.ExecuteScalar();
                if (result == null || result.ToString() == status) return false;

                string query = "UPDATE dbo.Tasks SET Status = @Status WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
