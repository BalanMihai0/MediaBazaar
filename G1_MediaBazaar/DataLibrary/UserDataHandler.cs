using StoreLibrary;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UserLibrary;

namespace DataLibrary
{
    /// <summary>
    /// this class is used for managing data of users
    /// </summary>

    public class UserDataHandler : IUserDataInterface
    {

        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedPassword;
            }
        }

        public string GeneratePassword(int length)
        {
            const string Symbols = "!@#$%^&*()_-+=<>?";
            const string Numbers = "0123456789";
            const string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string validChars = Symbols + Numbers + Capitals + Lowercase;

            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);

                var password = new char[length];
                var validCharCount = validChars.Length;

                for (var i = 0; i < length; i++)
                {
                    password[i] = validChars[bytes[i] % validCharCount];
                }

                return new string(password);
            }
        }
        void IUserDataInterface.AddUserToDatabase(User user)
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
                        string queryCheck = $"SELECT * FROM Users WHERE {user.Email}";
                        using (SqlCommand command = new SqlCommand(queryCheck, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                    throw new Exception("Employee exists!");
                            }
                        }


                        if (user is Employee employee)
                        {
                            string query1 = @$"INSERT INTO Employees 
                        (Employee_ID, Password, FirstName, LastName, PhoneNumber, HireDate, Job_ID, Salary, Manager_ID, Department_ID, Email) 
                        VALUES ({employee.ID},'{HashPassword(employee.Password)}', '{employee.FirstName}','{employee.LastName}','{employee.PhoneNumber}','{employee.HireDate}','{employee.JobID}','{employee.Salary}','{employee.ManagerID}','{employee.DepartmentID}','{employee.Email}')";

                            using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                            {
                                int rowsAffected = command1.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }
                        }

                        else if (user is Administrator administrator)
                        {
                            string query1 = @$"INSERT INTO Administrators
                        (Administrator_ID, Password, FirstName, LastName, HireDate) 
                        VALUES ({administrator.ID},'{HashPassword(administrator.Password)}','{administrator.FirstName}','{administrator.LastName}',{administrator.HireDate}','{administrator.Email})";

                            using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                            {
                                int rowsAffected = command1.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }
                        }

                        else if (user is Manager manager)
                        {
                            string query1 = @$"INSERT INTO Managers 
                        (Manager_ID, Password, FirstName, LastName, PhoneNumber, HireDate, Job_ID, Salary, Department_ID, Email) 
                        VALUES ({manager.ID},'{HashPassword(manager.Password)}', '{manager.FirstName}','{manager.LastName}','{manager.PhoneNumber}','{manager.HireDate}','{manager.JobID}','{manager.Salary}','{manager.DepartmentID}','{manager.Email}')";

                            using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                            {
                                int rowsAffected = command1.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
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
        }

        User IUserDataInterface.AuthenticateUser(string input, string password)
        {
            //check what kind of input
            if (Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return CheckUserLoginEmail(input, password);//by email
            }
            else if (Regex.IsMatch(input, @"^\d{5}$"))
            {
                return CheckUserLogin(int.Parse(input), password); // by id
            }
            else return null;
        }

        User CheckUserLogin(int id, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check for employees login 
                    string query = $"SELECT * FROM Employees WHERE Employee_ID = '{id}' AND Password = '{HashPassword(password)}'";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Employee employee = new Employee(
                                reader.GetInt32(reader.GetOrdinal("Employee_ID")),
                                reader.GetString(reader.GetOrdinal("FirstName")),
                                reader.GetString(reader.GetOrdinal("LastName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                reader.GetDouble(reader.GetOrdinal("Salary")),
                                reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                );
                                return employee; //type is employee
                            }
                        }
                    }
                    //check for manager login
                    string query2 = $"SELECT * FROM Managers WHERE Manager_ID = '{id}' AND Password = '{HashPassword(password)}'";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Manager manager = new Manager(
                                    reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                    reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    reader.GetDouble(reader.GetOrdinal("Salary")),
                                    reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                    );
                                return manager;
                            }
                        }
                    }

                    // Check for administrator login
                    string query1 = $"SELECT * FROM Administrators WHERE Administrator_ID = '{id}' AND Password = '{HashPassword(password)}'";
                    using (SqlCommand command1 = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Administrator administrator = new Administrator(
                                    reader.GetInt32(reader.GetOrdinal("Administrator_ID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    "admin@emal.com", // not in database, not needed for the admin account
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    DateTime.UtcNow // not in database, not needed for the admin account

                                );
                                return administrator;
                            }
                        }
                    }

                }
                return null; // no users match
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        User CheckUserLoginEmail(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check for employees login 
                    string query = $"SELECT * FROM Employees WHERE Email = '{email}' AND Password = '{HashPassword(password)}'";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Employee employee = new Employee(
                                reader.GetInt32(reader.GetOrdinal("Employee_ID")),
                                reader.GetString(reader.GetOrdinal("FirstName")),
                                reader.GetString(reader.GetOrdinal("LastName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                reader.GetDouble(reader.GetOrdinal("Salary")),
                                reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                );
                                return employee; //type is employee
                            }
                        }
                    }
                    //check for manager login
                    string query2 = $"SELECT * FROM Managers WHERE Email = '{email}' AND Password = '{HashPassword(password)}'";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Manager manager = new Manager(
                                    reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                    reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    reader.GetDouble(reader.GetOrdinal("Salary")),
                                    reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                    );
                                return manager;
                            }
                        }
                    }

                    // Check for administrator login
                    /*string query1 = $"SELECT * FROM Administrators WHERE Email = '{email}' AND Password = '{HashPassword(password)}'";
					using (SqlCommand command1 = new SqlCommand(query1, conn))
					{
						using (SqlDataReader reader = command1.ExecuteReader())
						{
							if (reader.Read())
							{
								Administrator administrator = new Administrator(
									reader.GetInt32(reader.GetOrdinal("Administrator_ID")),
									reader.GetString(reader.GetOrdinal("FirstName")),
									reader.GetString(reader.GetOrdinal("LastName")),
									"admin@email.com", // not in database, not needed for the admin account
									reader.GetString(reader.GetOrdinal("Password")),
									DateTime.UtcNow // not in database, not needed for the admin account

								);
								return administrator;
							}
						}
					}*/

                }
                return null; // no users match
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        int IUserDataInterface.GenerateNewId()
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
                    // checked employees
                    string query = $"SELECT COUNT(*) FROM Employees WHERE Employee_ID={id}";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                    // checked managers
                    string query2 = $"SELECT COUNT(*) FROM Managers WHERE Manager_ID={id}";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                    //check admins
                    string query1 = $"SELECT COUNT(*) FROM Administrators WHERE Administrator_ID={id}";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        idExists = (int)command.ExecuteScalar() > 0;
                    }
                }
            } while (idExists);

            return id;
        }

        void IUserDataInterface.UpdateUser(int idToUpdate, User newUser)
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
                        string query = "";
                        if (newUser is Employee employee)
                        {
                            if (employee.Password.Length < 30)
                                employee.Password = HashPassword(employee.Password);
                            query = @$"UPDATE Employees 
                            SET Password = '{employee.Password}', 
                                FirstName = '{employee.FirstName}', 
                                LastName = '{employee.LastName}', 
                                PhoneNumber = '{employee.PhoneNumber}', 
                                HireDate = '{employee.HireDate}', 
                                Job_ID = '{employee.JobID}', 
                                Salary = '{employee.Salary}', 
                                Manager_ID = '{employee.ManagerID}', 
                                Department_ID = '{employee.DepartmentID}',
                                Email = '{employee.Email}'
                            WHERE Employee_ID = '{idToUpdate}'";
                        }
                        else if (newUser is Administrator administrator)
                        {
                            if (administrator.Password.Length < 30)
                                administrator.Password = HashPassword(administrator.Password);
                            query = @$"UPDATE Administrators
                            SET Password = '{administrator.Password}', 
                                FirstName = '{administrator.FirstName}', 
                                LastName = '{administrator.LastName}', 
                                HireDate = '{administrator.HireDate}',
                                Email = '{administrator.Email}'
                            WHERE Administrator_ID = '{idToUpdate}'";
                        }
                        else if (newUser is Manager manager)
                        {
                            if (manager.Password.Length < 30)
                                manager.Password = HashPassword(manager.Password);
                            query = @$"UPDATE Managers 
                            SET Password = '{manager.Password}', 
                                FirstName = '{manager.FirstName}', 
                                LastName = '{manager.LastName}', 
                                PhoneNumber = '{manager.PhoneNumber}', 
                                HireDate = '{manager.HireDate}', 
                                Job_ID = '{manager.JobID}', 
                                Salary = '{manager.Salary}', 
                                Department_ID = '{manager.DepartmentID}',
                                Email = '{manager.Email}'
                            WHERE Manager_ID = '{idToUpdate}'";
                        }

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
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

        List<User> IUserDataInterface.GetAllEmployeesFromDataBase()
        {

            List<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Retrieve all employees
                    string query1 = @"SELECT * FROM Employees";
                    using (SqlCommand command1 = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string password = reader.GetString(1);
                                string firstName = reader.GetString(2);
                                string lastName = reader.GetString(3);
                                string phoneNumber = reader.GetString(4);
                                var hireDate = reader.GetDateTime(5);
                                int jobID = reader.GetInt32(6);
                                var salary = reader.GetDouble(7);
                                int managerID = reader.GetInt32(8);
                                int departmentID = reader.GetInt32(9);
                                string email = reader.GetString(10);

                                Employee employee = new Employee(id, firstName, lastName, email, password, jobID, hireDate, phoneNumber, salary, managerID, departmentID);


                                users.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return users;

        }

        List<Manager> IUserDataInterface.GetAllManagersFromDatabase()
        {

            List<Manager> users = new List<Manager>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Retrieve all employees
                    string query1 = @"SELECT * FROM Managers";
                    using (SqlCommand command1 = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Manager manager = new Manager(
                                    reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                    reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    reader.GetDouble(reader.GetOrdinal("Salary")),
                                    reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                );
                                users.Add(manager);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return users;

        }

        Employee IUserDataInterface.GetEmployee(int id)
        {
            Employee employee = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = $"SELECT * FROM Employees WHERE Employee_ID = {id}";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    employee = new Employee((int)reader[0], (string)reader[2], (string)reader[3], (string)reader[10], (string)reader[1], (int)reader[6], (DateTime)reader[5], (string)reader[4], (double)reader[7], (int)reader[8], (int)reader[9]);
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
            return employee;
        }

        bool IUserDataInterface.ReassignEmployeesToDept(List<Employee> reassignedEmployees)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                foreach (var employee in reassignedEmployees)
                {
                    string query = "UPDATE Employees SET Manager_ID = @managerID, Department_ID = @departmentID WHERE Employee_ID = @employeeID";

                    using SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@managerID", employee.ManagerID);
                    cmd.Parameters.AddWithValue("@departmentID", employee.DepartmentID);
                    cmd.Parameters.AddWithValue("@employeeID", employee.ID);

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

        void IUserDataInterface.DeleteEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"DELETE FROM Employees WHERE Email = {employee.Email}";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        bool IUserDataInterface.UnassignManagerFromDept(int managerID)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                string query = "UPDATE Managers SET Department_ID = @departmentID WHERE Manager_ID = @managerID";

                using SqlCommand cmd = new SqlCommand(query, conn, transaction);
                cmd.Parameters.AddWithValue("@departmentID", 12345);
                cmd.Parameters.AddWithValue("@managerID", managerID);

                int rowsAffedcted = cmd.ExecuteNonQuery();

                transaction.Commit();

                return true;
            }
            catch (SqlException)
            {
                transaction.Rollback();

                return false;
            }
        }
        User IUserDataInterface.GetUser(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check for employees login 
                    string query = $"SELECT * FROM Employees WHERE Employee_ID = {id}";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Employee employee = new Employee(
                                reader.GetInt32(reader.GetOrdinal("Employee_ID")),
                                reader.GetString(reader.GetOrdinal("FirstName")),
                                reader.GetString(reader.GetOrdinal("LastName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                reader.GetDouble(reader.GetOrdinal("Salary")),
                                reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                );
                                return employee; //type is employee
                            }
                        }
                    }
                    //check for manager login
                    string query2 = $"SELECT * FROM Managers WHERE Manager_ID = {id}";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Manager manager = new Manager(
                                    reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                    reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    reader.GetDouble(reader.GetOrdinal("Salary")),
                                    reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                    );
                                return manager;
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        User IUserDataInterface.GetUser(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check for employees login 
                    string query = $"SELECT * FROM Employees WHERE Email = {email}";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Employee employee = new Employee(
                                reader.GetInt32(reader.GetOrdinal("Employee_ID")),
                                reader.GetString(reader.GetOrdinal("FirstName")),
                                reader.GetString(reader.GetOrdinal("LastName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                reader.GetDouble(reader.GetOrdinal("Salary")),
                                reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                );
                                return employee; //type is employee
                            }
                        }
                    }
                    //check for manager login
                    string query2 = $"SELECT * FROM Managers WHERE Email = {email}";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Manager manager = new Manager(
                                    reader.GetInt32(reader.GetOrdinal("Manager_ID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                    reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    reader.GetDouble(reader.GetOrdinal("Salary")),
                                    reader.GetInt32(reader.GetOrdinal("Job_ID")),
                                    reader.GetInt32(reader.GetOrdinal("Department_ID"))
                                    );
                                return manager;
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        bool IUserDataInterface.CheckOldPass(string oldPass, UserLibrary.User user)
        {
            if (HashPassword(oldPass) == user.Password)
                return true;
            return false;
        }
        string IUserDataInterface.ResetUserPassword(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    bool userExists = false;
                    conn.Open();

                    // Check for employees login 
                    string query = $"SELECT * FROM Employees WHERE Email = '{email}'";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userExists = true;
                            }
                        }
                    }
                    if (userExists)
                    {
                        string newPass = GeneratePassword(10);
                        string query1 = $"UPDATE Employees SET Password = '{HashPassword(newPass)}' WHERE Email = '{email}'";
                        using (SqlCommand command = new SqlCommand(query1, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                        return newPass;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}