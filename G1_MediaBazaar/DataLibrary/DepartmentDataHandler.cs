using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
using StoreLibrary;
using UserLibrary;

namespace DataLibrary
{

    /// <summary>
    /// for department insertion, location is already going to be selected - granted no pointing to empty table row
    /// </summary>
    public class DepartmentDataHandler : IDepartmentsDataInterface //info in interface definition
    {
        private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

		List<Department> IDepartmentsDataInterface.GetDepartments()
		{

			List<Department> departments = new List<Department>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string query1 = @"SELECT * FROM Departments";
					using (SqlCommand command1 = new SqlCommand(query1, conn))
					{
						using (SqlDataReader reader = command1.ExecuteReader())
						{
							while (reader.Read())
							{
                                Department department = new Department(
                                    reader.GetInt32(reader.GetOrdinal("Department_ID")),
                                    reader.GetString(reader.GetOrdinal("DepartmentName")),
                                    reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Location_ID")));


                                departments.Add(department);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}

			return departments;

		}

        void IDepartmentsDataInterface.AddDepartmentToDatabase(StoreLibrary.Department department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the location is already assigned to another department
                    string checkQuery = @$"SELECT COUNT(*) FROM Departments WHERE Location_ID = '{department.LocationId}'";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new InvalidDepartmentException("Location is already assigned to another department.");
                        }
                    }

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string insertQuery = @$"INSERT INTO Departments 
                    (Department_ID, DepartmentName, Manager_ID, Location_ID) 
                    VALUES ('{department.Id}', '{department.DepartmentName}','{department.ManagerId}','{department.LocationId}')";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn, transaction))
                        {
                            int rowsAffected = insertCommand.ExecuteNonQuery();
                            Console.WriteLine($"Inserted {rowsAffected} row(s)");
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch(InvalidDepartmentException ide)
            {
                throw new InvalidDepartmentException(ide.Message);
                //exception is thrown to DepartmentsManager
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        void IDepartmentsDataInterface.RemoveDepartmentFromDatabase(int id) 
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
                        string query = $"DELETE FROM Departments WHERE Department_ID = {id}";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"Deleted {rowsAffected} row(s)");
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

        int IDepartmentsDataInterface.GenerateNewDepartmentId()
        {
            Random random = new Random();
            int id;
            bool idExists;

            do
            {
                // Generate a random integer ID 
                id = random.Next(10000, 99999);

                // Check if the ID already exists in the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //check departments
                    string query1 = $"SELECT COUNT(*) FROM Departments WHERE Department_ID={id}";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                }
            } while (idExists);

            return id;
        }

        void IDepartmentsDataInterface.ChangeDepartmentManager(int departmentId, int newManagerId)
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
                        string query = $"UPDATE Departments SET Manager_ID = {newManagerId} WHERE Department_ID = {departmentId}";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"Updated {rowsAffected} row(s)");
                        }
                        string query1 = $"UPDATE Managers SET Department_ID = {departmentId} WHERE Manager_ID = {newManagerId}";

                        using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                        {
                            int rowsAffected = command1.ExecuteNonQuery();
                            Console.WriteLine($"Updated {rowsAffected} row(s)");
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
        Department IDepartmentsDataInterface.GetDepartment(int id)
        {
            Department department = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = $"SELECT * FROM Departments WHERE Department_ID = {id}";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    department = new Department(reader.GetInt32(reader.GetOrdinal("Department_ID")),
                                            reader.GetString(reader.GetOrdinal("DepartmentName")),
                                            reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                            reader.GetInt32(reader.GetOrdinal("Location_ID")));
                                }
                            }
                        }
                        transaction.Commit();
                        return department;
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
