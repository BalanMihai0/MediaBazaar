using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLibrary;
using UserLibrary;
using SharedLibrary;
using System.Transactions;

namespace DataLibrary
{
    public class WorkshiftDataHandler : IWorkshiftDataInterface
    {
        private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

        int IWorkshiftDataInterface.GenerateNewWorkshiftId()
        {
            Random random = new Random();
            int id;
            bool idExists;
            do
            {
                id = random.Next(10000, 99999);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //check departments
                    string query1 = $"SELECT COUNT(*) FROM Workshifts WHERE id={id}";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                }
            }
            while (idExists);

            return id;
        }
        void IWorkshiftDataInterface.AddWorkshiftToDatabase(StoreLibrary.Workshift workshift)
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
                        string query1 = @$"INSERT INTO Workshifts(id, employeeId, date, timeOfShift, departmentId) VALUES ('{workshift.Id}', '{workshift.Employee.Item1}', '{workshift.Date}', {(int)workshift.ShiftTime}, {workshift.DepartmentId})";

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
        List<Workshift> IWorkshiftDataInterface.GetAllWorkshiftsFromDatabase()
        {
            List<Workshift> workshifts = new List<StoreLibrary.Workshift>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    string query = $"SELECT * FROM Workshifts";

                    using (SqlCommand command = new SqlCommand(query, conn, transaction))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            foreach (var item in reader)
                            {
                                Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>((int)reader[1], null);
                                workshifts.Add(new Workshift((int)reader[0], tempTuple, DateOnly.FromDateTime((DateTime)reader[2]), (ShiftTimeEnum)reader[3], (int)reader[4]));
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return workshifts;
        }
        void IWorkshiftDataInterface.RemoveWorkshiftFromDatabase(StoreLibrary.Workshift workshift)
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
                        string query = $"DELETE FROM Workshifts WHERE id = {workshift.Id}";

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
        List<Workshift> IWorkshiftDataInterface.EmployeeWorkshifts(System.DateOnly? date, UserLibrary.Employee employee = null, int departmentId = 0)
        {
            List<Workshift> workshifts = new List<Workshift>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = "";

                        if (employee == null && departmentId != -2)
                            query = $"SELECT * FROM Workshifts WHERE departmentId = {departmentId}";
                        else if (departmentId == -2 && employee != null)
                            query = $"SELECT * FROM Workshifts WHERE employeeId = {employee.ID}";
                        else if (employee == null && departmentId == -2)
                            query = $"SELECT * FROM Workshifts";
                        if (date != null)
                        {
                            string dateAdd = $" AND date = '{date}'";
                            if (query == "SELECT * FROM Workshifts")
                                dateAdd = $" WHERE date = '{date}'";
                            query += dateAdd;
                        }
                        query += " ORDER BY timeOfShift ASC";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                foreach (var item in reader)
                                {
                                    Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>((int)reader[1], null);
                                    workshifts.Add(new Workshift((int)reader[0], tempTuple, DateOnly.FromDateTime((DateTime)reader[2]), (ShiftTimeEnum)reader[3], (int)reader[4]));
                                }
                            }
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
            foreach (var item in workshifts)
            {
                Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>(item.Employee.Item1, MediaBazzar.Instance.UserManager.FindEmployee(item.Employee.Item1));
                item.SetEmployee(tempTuple);
            }
            return workshifts;
        }
        List<Workshift> IWorkshiftDataInterface.EmployeeWorkshifts(System.DateOnly date, int departmentId)
        {
            List<Workshift> workshifts = new List<Workshift>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = $"SELECT * FROM Workshifts WHERE date = '{date.ToDateTime(new TimeOnly(12, 00))}' AND departmentId = {departmentId} ORDER BY timeOfShift ASC;";


                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                foreach (var item in reader)
                                {
                                    Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>((int)reader[1], null);
                                    workshifts.Add(new Workshift((int)reader[0], tempTuple, DateOnly.FromDateTime((DateTime)reader[2]), (ShiftTimeEnum)reader[3], (int)reader[4]));
                                }
                            }
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
            foreach (var item in workshifts)
            {
                Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>(item.Employee.Item1, MediaBazzar.Instance.UserManager.FindEmployee(item.Employee.Item1));
                item.SetEmployee(tempTuple);
            }
            return workshifts;
        }
		bool IWorkshiftDataInterface.RemoveWorkshiftsForEmployee(Employee employee)
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
						string query = $"DELETE FROM Workshifts WHERE employeeId = {employee.ID}";

						using (SqlCommand command = new SqlCommand(query, conn, transaction))
						{
							int rowsAffected = command.ExecuteNonQuery();
							Console.WriteLine($"Deleted {rowsAffected} row(s)");
						}
						transaction.Commit();

                        return true;
					}
					catch (Exception ex)
					{
						// If any exceptions were thrown, roll back the transaction
						Console.WriteLine($"An error occurred: {ex.Message}");
						transaction.Rollback();

                        return false;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");

                return false;
			}
		}
	}
}
