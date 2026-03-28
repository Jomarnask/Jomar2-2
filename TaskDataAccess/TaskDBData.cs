using Microsoft.Data.SqlClient;
using TaskModel;

namespace TaskDataAccess
{
    public class TaskDBData
    {
        private string connectionString
            = "Data Source=localhost\\SQLEXPRESS02; Initial Catalog=Tasks; Integrated Security=True; TrustServerCertificate=True;";

        // GET ALL TASKS
        public List<TaskItem> GetAll()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Name, Status FROM dbo.Tasks";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }
            return tasks;
        }

        // ADD TASK
        public void Add(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO dbo.Tasks (Name, Status) VALUES (@Name, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Status", "Not Done");
                cmd.ExecuteNonQuery();
            }
        }

        // EDIT TASK
        public void Edit(int id, string newName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE dbo.Tasks SET Name = @Name WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE TASK
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM dbo.Tasks WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // MARK TASK
        public bool Mark(int id, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // check current status first
                string checkQuery = "SELECT Status FROM dbo.Tasks WHERE Id = @Id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Id", id);
                string currentStatus = checkCmd.ExecuteScalar().ToString();

                // if already same status, return false
                if (currentStatus == status)
                    return false;

                // update the status
                string query = "UPDATE dbo.Tasks SET Status = @Status WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}