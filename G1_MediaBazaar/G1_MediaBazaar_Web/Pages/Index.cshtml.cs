using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using StoreLibrary;
using UserLibrary;
using System.Linq;

namespace G1_MediaBazaar_Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Announcement> Announcements { get; set; }

        public List<Manager> Managers { get; set; }

        public List<Workshift> Workshifts { get; set; }

        public void OnGet()
        {
            try
            {
                Announcements = MediaBazzar.Instance.AnnouncementManager.GetAllAnnouncements();
                Managers = MediaBazzar.Instance.UserManager.GetAllManagers();

                var currID = int.Parse(User.FindFirst("ID").Value);

                Workshifts = new List<Workshift>();

                var currEmp = MediaBazzar.Instance.UserManager.GetUser(currID);
                if (currEmp is Employee m)
                {
                    Workshifts = MediaBazzar.Instance.WorkshiftsManager.EmployeeWorkshifts(null, m);

                    Workshifts = Workshifts.Where(w => w.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) >= 0 && w.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now.AddDays(2))) <= 0).OrderBy(w => w.Date).ToList();

                    if (Workshifts.Count > 0)
                    {
                        while (true)
                        {
                            if (Workshifts[0].StartTime.CompareTo(DateTime.Now) <= 0)
                            {
                                Workshifts.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}