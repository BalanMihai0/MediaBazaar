using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary
{
    public interface IUserDataInterface
    {
        void AddUserToDatabase(User user);
        void DeleteEmployee(Employee employee);
        int GenerateNewId();
        void UpdateUser(int idToUpdate, User newUser);
        List<User> GetAllEmployeesFromDataBase();
        Employee GetEmployee(int id);
        List<Manager> GetAllManagersFromDatabase();
        User AuthenticateUser(string input, string password);
        bool ReassignEmployeesToDept(List<Employee> reassignedEmployees);
        bool UnassignManagerFromDept(int managerID);
        User GetUser(int id);
        User GetUser(string email);
        bool CheckOldPass(string oldPass, User user);
        string ResetUserPassword(string email);
    }
}
