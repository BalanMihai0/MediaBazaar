using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;
//using DataLibrary.Data;

namespace DataLibrary
{
    public class LocationDataHandler:ILocationsDataInterface
    {
        private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

        int ILocationsDataInterface.GenerateNewLocationId()
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
                    string query1 = $"SELECT COUNT(*) FROM Locations WHERE Location_ID={id}";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                }
            } while (idExists);

            return id;
        }

        void ILocationsDataInterface.AddLocationToDatabase(StoreLibrary.Location location) 
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
                        string query1 = @$"INSERT INTO Locations 
                        (Location_ID, FLoor, RoomNumber) 
                        VALUES ('{location.LocationId}', '{location.Floor}','{location.RoomNumber}')";

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

        void ILocationsDataInterface.RemoveLocationFromDatabase(int id) 
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
                        string query = $"DELETE FROM Locations WHERE Location_ID = {id}";

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

		List<Location> ILocationsDataInterface.GetLocations()
		{
			List<Location> locations = new List<Location>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string query = @"SELECT * FROM Locations";
					using (SqlCommand command1 = new SqlCommand(query, conn))
					{
						using (SqlDataReader reader = command1.ExecuteReader())
						{
							while (reader.Read())
							{
                                Location location = new Location(
                                    reader.GetInt32(reader.GetOrdinal("Location_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Floor")),
                                    reader.GetInt32(reader.GetOrdinal("RoomNumber")));
								
                                locations.Add(location);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}

			return locations;
		}
	}
}
