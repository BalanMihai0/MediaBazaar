using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using StoreLibrary;
using Newtonsoft.Json;
using UserLibrary;

namespace G1_MediaBazaar_Web.Pages
{
    [Authorize]
    public class ScheduleModel : PageModel
    {
        public List<Workshift> workshifts { get; set; }

        public string UserType { get; set; }

        public void OnGet()
        {
            try
            {
                User current = MediaBazzar.Instance.UserManager.GetUser(int.Parse(User.FindFirst("ID").Value));
                if (current is Employee employee)
                {
                    UserType = "Employee";
                    workshifts = MediaBazzar.Instance.WorkshiftsManager.EmployeeWorkshifts(null, employee);
                }
                else
                {
                    UserType = "Manager";
                }
                string workshiftsJson = JsonConvert.SerializeObject(workshifts);
                ViewData["WorkshiftsJson"] = workshiftsJson;
            }
            catch (Exception ex) { }
        }
    }
}