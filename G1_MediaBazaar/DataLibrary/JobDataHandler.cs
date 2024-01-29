using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class JobDataHandler : IJobDataInterface
    {
        private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

        void IJobDataInterface.AddJobToDatabase(Job job)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query1 = @$"INSERT INTO Jobs 
                        (Job_ID, JobTitle, MinSalary, MaxSalary) 
                        VALUES ('{job.Id}', '{job.JobTitle}','{job.MinSalary}','{job.MaxSalary}')";

                        using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                        {
                            int rowsAffected = command1.ExecuteNonQuery();
                            Console.WriteLine($"Inserted {rowsAffected} row(s)");
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If any exceptions were thrown, roll back the transaction
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        int IJobDataInterface.GetNextId()
        {
            int nextId = 1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 Job_ID FROM Jobs ORDER BY Job_ID DESC";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            nextId = reader.GetInt32(0) + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return nextId;
        }

        List<Job> IJobDataInterface.GetAllJobs()
        {
            List<Job> jobs = new List<Job>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT Job_ID, JobTitle, MinSalary, MaxSalary FROM Jobs";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Job job = new Job
                                (
                                    reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                    reader.GetString(reader.GetOrdinal("JobTitle")),
                                    reader.GetDouble(reader.GetOrdinal("MinSalary")),
                                    reader.GetDouble(reader.GetOrdinal("MaxSalary"))
                                );
                                jobs.Add(job);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return jobs;
        }
        Job IJobDataInterface.GetJob(int id)
        {
            try
            {
                Job job;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = "SELECT JobTitle, MinSalary, MaxSalary FROM Jobs WHERE Job_ID = @jobId";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            command.Parameters.AddWithValue("@jobId", id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // If there are no rows, call the callback with null
                                if (!reader.Read())
                                {
                                    return null;
                                }

                                // Extract the data from the reader and create a new Job object
                                string jobTitle = reader.GetString(0);
                                double minSalary = reader.GetDouble(1);
                                double maxSalary = reader.GetDouble(2);
                                job = new Job(id, jobTitle, minSalary, maxSalary);

                            }
                        }

                        transaction.Commit();
                        return job;
                    }
                    catch (Exception ex)
                    {
                        // If any exceptions were thrown, roll back the transaction
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }

    }
}
