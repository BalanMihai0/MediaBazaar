using SharedLibrary;
using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;

namespace DataLibrary
{
	public class AvailabilityDataHandler : IAvailability
	{
		private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

        public void AddAvailability(Availability availability)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query1 = @"INSERT INTO Availability (EmployeeID, weekday, timeOfDay, Date) VALUES (@EmployeeID, @Weekday, @Time, @Date)";
                    using (SqlCommand command1 = new SqlCommand(query1, conn))
                    {
                        DateOnly dateOnly = availability.Date;
                        DateTime dateTime = DateTime.Parse(dateOnly.ToString());
                        command1.Parameters.AddWithValue("@EmployeeID", availability.Employee.ID);
                        command1.Parameters.AddWithValue("@Weekday", (int)availability.ShiftAvailibility.Item1);
                        command1.Parameters.AddWithValue("@Time", (int)availability.ShiftAvailibility.Item2);
                        command1.Parameters.AddWithValue("@Date", dateTime);

                        command1.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public List<Availability> AvailaibilityOfEmployee(Employee employee)
		{
			List<Availability> result = new List<Availability>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string query1 = @$"SELECT * FROM Availability where EmployeeID ={employee.ID} ";
					using (SqlCommand command1 = new SqlCommand(query1, conn))
					{
						using (SqlDataReader reader = command1.ExecuteReader())
						{
							while (reader.Read())
							{
								int employeeID = reader.GetInt32(0);
								var emp = (Employee)MediaBazzar.Instance.UserManager.GetUser(employeeID);
								var weekday = (Weekday)reader.GetInt32(1);
								var timeOfDay = (AvailabilityTimeEnum)reader.GetInt32(2);
								var date = DateOnly.FromDateTime(reader.GetDateTime(3));

								result.Add(new Availability(emp, weekday, timeOfDay, date));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}

			return result;
		}

		public void DeleteAvailability(Availability availability)
		{
			SqlTransaction transaction = null;

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					transaction = conn.BeginTransaction();

					string query1 = @$"DELETE FROM Availability WHERE EmployeeID = {availability.Employee.ID} AND weekday = {(int)availability.ShiftAvailibility.Item1} AND timeOfDay = {(int)availability.ShiftAvailibility.Item2}";
					using (SqlCommand command1 = new SqlCommand(query1, conn))
					{
						command1.ExecuteNonQuery();
					}

					transaction.Commit();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");

				if (transaction != null)
				{
					transaction.Rollback();
				}
			}
		}
	}
}
