
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;
using Google.Apis.Services;
namespace UserLibrary
{
    public class UserManager
    {

        private readonly IUserDataInterface _userDataHandler;

        public UserManager(IUserDataInterface dataStorage)
        {
            _userDataHandler = dataStorage;
        }

        public User AuthenthicateUser(string input, string password)
        {
            return _userDataHandler.AuthenticateUser(input, password);
        }

        public int GenerateId()
        {
            return _userDataHandler.GenerateNewId();
        }
        public void AddEmployee(User user)
        {
            _userDataHandler.AddUserToDatabase(user);
        }

        public List<User> GetAllUsers()
        {
            return _userDataHandler.GetAllEmployeesFromDataBase();
        }

        public List<Manager> GetAllManagers()
        {
            List<Manager> users = _userDataHandler.GetAllManagersFromDatabase();
            return users;
        }

        public List<User> GetAllEmployees()
        {
            return _userDataHandler.GetAllEmployeesFromDataBase();
        }

        public void UpdateUser(int idToUpdate, User newUser)
        {
            _userDataHandler.UpdateUser(idToUpdate, newUser);
        }

        public void PromoteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public User? SearchUser(string searchQuery)
        {

            return null;
        }
        public Employee FindEmployee(int id)
        {
            return _userDataHandler.GetEmployee(id);
        }
        public void RemoveUser(Employee employee)
        {
            _userDataHandler.DeleteEmployee(employee);
        }

        public bool ReassignEmployeesToDept(List<Employee> reassignedEmployees)
        {
            return _userDataHandler.ReassignEmployeesToDept(reassignedEmployees);
        }

        public bool UnassignManagerFromDept(int managerID)
        {
            return _userDataHandler.UnassignManagerFromDept(managerID);
        }
        public User GetUser(int id)
        {
            return _userDataHandler.GetUser(id);
        }
        public bool CheckOldPass(string oldPass, User user)
        {
            return _userDataHandler.CheckOldPass(oldPass, user);
        }
        public async void SendEmail(string emailAddress, string message, string subject)
        {
            try
            {
                // Replace with your own credentials
                string fromEmail = "mediabazaarGR1@gmail.com";
                string password = "euydzlbzkxsosavv";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587; // Use 587 for TLS

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromEmail);
                mailMessage.To.Add(emailAddress);
                mailMessage.Subject = subject;
                mailMessage.Body = message;

                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public User GetUser(string email)
        {
            return _userDataHandler.GetUser(email);
        }
        public void ResetUserPassword(string email)
        {
            string newPass = _userDataHandler.ResetUserPassword(email);
            if (newPass != null)
            {
                SendEmail(email, "Your password has been reset! Here is your new password: " + newPass, "Reset password for MediaBazaar");
            }
        }
    }
}