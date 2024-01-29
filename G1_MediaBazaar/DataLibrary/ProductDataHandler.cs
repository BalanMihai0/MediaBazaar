using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;
using DataLibrary;
using SharedLibrary;

namespace DataLibrary
{
    public class ProductDataHandler : IProductDataInterface
    {
        
        private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

        int IProductDataInterface.GenerateNewProductId()
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
                    string query1 = $"SELECT COUNT(*) FROM Products WHERE id={id}";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                }
            }
            while (idExists);

            return id;
        }
        void IProductDataInterface.AddProductToDatabase(StoreLibrary.Product product)
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
                        string query1 = @$"INSERT INTO Products(id, name, departmentId, stock, description) VALUES ('{product.Id}', '{product.Name}', '{product.Department.Id}', '{product.Stock}', '{product.Description}')";

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
        void IProductDataInterface.RemoveProductFromDatabase(StoreLibrary.Product product)
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
                        string query = $"DELETE FROM Products WHERE id = {product.Id}";

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
        Product IProductDataInterface.GetProductFromDatabase(StoreLibrary.Product product)
        {
            Product productFromDB = product;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = $"SELECT * FROM Products WHERE id = {product.Id}";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    productFromDB = new Product((int)reader[0], (string)reader[1], (string)reader[4], null, (int)reader[2], (int)reader[3]);
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

            productFromDB.SetDept(MediaBazzar.Instance.DepartmentsManager.GetDepartment(productFromDB.DepartmentId));
            
            return productFromDB;
        }
        void IProductDataInterface.UpdateStock(StoreLibrary.Product product)
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
                        string query1 = @$"UPDATE Products SET stock = {product.Stock} WHERE id = {product.Id};";

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

        List<Product> IProductDataInterface.GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = $"SELECT * FROM Products";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                foreach (var item in reader)
                                {
                                    products.Add(new Product((int)reader[0], (string)reader[1], (string)reader[4], null, (int)reader[2], (int)reader[3]));
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
            foreach (var item in products)
            {
                item.SetDept(MediaBazzar.Instance.DepartmentsManager.GetDepartment(item.DepartmentId));
            }
            return products;
        }

		bool IProductDataInterface.ReassignProdsToDept(List<Product> reassignedProds)
		{
			using SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();

			SqlTransaction transaction = conn.BeginTransaction();

			try
			{
				foreach (var product in reassignedProds)
				{
					string query = "UPDATE Products SET departmentId = @departmentID WHERE id = @productID";

					using SqlCommand cmd = new SqlCommand(query, conn, transaction);
					cmd.Parameters.AddWithValue("@departmentID", product.DepartmentId);
					cmd.Parameters.AddWithValue("@productID", product.Id);

					int rowsAffedcted = cmd.ExecuteNonQuery();
				}

				transaction.Commit();

				return true;
			}
			catch (SqlException)
			{
				transaction.Rollback();

				return false;
			}
		}
	}
}
