using G1_MediaBazaar_Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SharedLibrary;
using StoreLibrary;
using System;
using System.Collections.Generic;
using UserLibrary;

namespace G1_MediaBazaar_Web.Pages
{
    public class AvailabilityModel : PageModel
    {
        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public string TimeOfDay { get; set; }

        public List<EventsOfAvailability> events { get; set; } = new List<EventsOfAvailability>();

        public void OnGet()
        {
            try
            {
                User loggedInUser = MediaBazzar.Instance.UserManager.GetUser(int.Parse(User.FindFirst("ID").Value));
                List<Availability> availabilities = MediaBazzar.Instance.AvailabilityManager.AvailaibilityOfEmployee((Employee)loggedInUser);
                foreach (var item in availabilities)
                {
                    if(item.Date> DateOnly.FromDateTime(DateTime.Now))
                    {
                        EventsOfAvailability eventsOfAvailability =
                        new EventsOfAvailability(
                        item.Date.ToString("MM/dd/yyyy") + " " + GetAvailabilityStartTime(item.ShiftAvailibility.Item2),
                        item.Date.ToString("MM/dd/yyyy") + " " + GetAvailabilityEndTime(item.ShiftAvailibility.Item2)
                        );
                        events.Add(eventsOfAvailability);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                User loggedInUser = MediaBazzar.Instance.UserManager.GetUser(int.Parse(User.FindFirst("ID").Value));
                Employee loggedIn = (Employee)loggedInUser;

                Weekday weekday = Enum.Parse<Weekday>(Date.DayOfWeek.ToString());
                AvailabilityTimeEnum timeOfWeek = Enum.Parse<AvailabilityTimeEnum>(TimeOfDay.ToString());
                Availability newAvailability = new Availability(loggedIn, weekday, timeOfWeek, DateOnly.FromDateTime(Date));

                MediaBazzar.Instance.AvailabilityManager.AddAvailability(newAvailability);
            }
            catch (NullReferenceException)
            {
                // Handle the exception appropriately
            }

            return RedirectToPage("/Availability");
        }

        public string GetAvailabilityStartTime(AvailabilityTimeEnum a)
        {
            if (a == AvailabilityTimeEnum.Morning)
            {
                return "8:00";
            }
            else if (a == AvailabilityTimeEnum.Afternoon)
            {
                return "12:00";
            }
            else
            {
                return "16:00";
            }
        }

        public string GetAvailabilityEndTime(AvailabilityTimeEnum a)
        {
            if (a == AvailabilityTimeEnum.Morning)
            {
                return "12:00";
            }
            else if (a == AvailabilityTimeEnum.Afternoon)
            {
                return "16:00";
            }
            else
            {
                return "20:00";
            }
        }
    }
}