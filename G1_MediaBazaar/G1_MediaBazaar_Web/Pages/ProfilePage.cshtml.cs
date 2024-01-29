using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLibrary;
using SharedLibrary;
using StoreLibrary;

namespace G1_MediaBazaar_Web.Pages
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        public Type UserType { get; set; }
        public Employee employee { get; set; }
        public Department dept { get; set; }
        public Job employeeJob { get; set; }
        public Manager manager { get; set; }
        public Administrator admin { get; set; }
        [BindProperty]
        public ProfileUpdate profileForm { get; set; }
        public RedirectToPageResult OnGet()
        {
            try
            {
                if (User.FindFirst("ID").Value == null)
                {
                    return RedirectToPage("Login");
                }
                User user = MediaBazzar.Instance.UserManager.GetUser((int.Parse(User.FindFirst("ID").Value)));
                profileForm = new ProfileUpdate();
                if (user is Employee employee)
                {
                    profileForm.email = employee.Email;
                    profileForm.firstName = employee.FirstName;
                    profileForm.lastName = employee.LastName;
                    profileForm.phoneNumber = employee.PhoneNumber;
                    UserType = typeof(Employee);
                    this.employee = employee;
                    if (employee.DepartmentID != null)
                        dept = MediaBazzar.Instance.DepartmentsManager.GetDepartment((int)employee.DepartmentID);
                    if (employee.ManagerID != null)
                    {
                        User temp = MediaBazzar.Instance.UserManager.GetUser((int)employee.ManagerID);
                        manager = (Manager)temp;
                    }
                    employeeJob = MediaBazzar.Instance.JobsManager.GetJob(employee.JobID);
                }
                else if (user is Manager manager)
                {
                    UserType = typeof(Manager);
                    this.manager = manager;
                    if (manager.DepartmentID != null)
                        dept = MediaBazzar.Instance.DepartmentsManager.GetDepartment((int)manager.DepartmentID);
                    employeeJob = MediaBazzar.Instance.JobsManager.GetJob(manager.JobID);
                }
                else if (user is Administrator admin)
                {
                    UserType = typeof(Administrator);
                    this.admin = admin;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        public RedirectToPageResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (User.FindFirst("ID").Value == null)
                    {
                        return RedirectToPage("Login");
                    }
                    User user = MediaBazzar.Instance.UserManager.GetUser((int.Parse(User.FindFirst("ID").Value)));
                    if (user is Employee employee)
                    {
                        if (profileForm.firstName != null)
                            employee.FirstName = profileForm.firstName;
                        if (profileForm.lastName != null)
                            employee.LastName = profileForm.lastName;
                        if (profileForm.email != null)
                            employee.Email = profileForm.email;
                        if (profileForm.phoneNumber != null)
                            employee.PhoneNumber = profileForm.phoneNumber;
                        if (profileForm.oldPass != null)
                        {
                            if (profileForm.newPass != null)
                            {
                                if (MediaBazzar.Instance.UserManager.CheckOldPass(profileForm.oldPass, employee))
                                {
                                    employee.Password = profileForm.newPass;
                                }
                            }
                        }

                    }
                    MediaBazzar.Instance.UserManager.UpdateUser(user.ID, user);
                    return RedirectToPage("ProfilePage");
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
