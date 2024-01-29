using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using StoreLibrary;
using System.Security.Claims;
using UserLibrary;

namespace G1_MediaBazaar_Web.Pages
{
    public class LogInPageModel : PageModel
    {
        private readonly ILogger<LogInPageModel> _logger;

        public LogInPageModel(ILogger<LogInPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            TempData["Admin-attempt"] = 0;
        }
        [BindProperty]
        public string EmployeeId { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            try
            {
                User? tempUser = MediaBazzar.Instance.UserManager.AuthenthicateUser(EmployeeId, Password);
                TempData["Admin-attempt"] = 0;
                if (tempUser != null)
                {
                    if (tempUser is Manager manager)
                    {
                        var claims = new List<Claim>
                {
                    new Claim("ID", tempUser.ID.ToString()),
                    new Claim("Username", tempUser.FirstName + " " + tempUser.LastName),
                    new Claim("Email", tempUser.Email),
                    new Claim("IPAddress", HttpContext.Connection.RemoteIpAddress.ToString()),
                    new Claim("FirstName", tempUser.FirstName),
                    new Claim("LastName", tempUser.LastName),
                    new Claim("DepartmentID", ((Manager)tempUser).DepartmentID.ToString())
                };

                        var claimsidentiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddHours(2),
                            IsPersistent = false // RememberMe
                        };
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentiy), authProperties);
                        return RedirectToPage("/Index");
                    }
                    if (tempUser is Employee emp)
                    {
                        var claims = new List<Claim>
                {
                    new Claim("ID", tempUser.ID.ToString()),
                    new Claim("Username", tempUser.FirstName + " " + tempUser.LastName),
                    new Claim("Email", tempUser.Email),
                    new Claim("IPAddress", HttpContext.Connection.RemoteIpAddress.ToString()),
                    new Claim("FirstName", tempUser.FirstName),
                    new Claim("LastName", tempUser.LastName),
                    new Claim("DepartmentID", ((Employee)tempUser).DepartmentID.ToString()),
                    new Claim("ManagerID", ((Employee) tempUser).ManagerID.ToString())
                };

                        var claimsidentiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddHours(2),
                            IsPersistent = false // RememberMe
                        };
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentiy), authProperties);
                        return RedirectToPage("/Index");
                    }
                    TempData["Admin-attempt"] = 1;
                    return Page();
                }
                else
                {
                    //login failed
                    ErrorMessage = "Credentials did not match";
                    return RedirectToPage("/LogInPage");
                }
            }
            catch (Exception ex) { }
            return null;
        }

        private bool IsValid(string employeeId, string password)
        {
            try
            {
                User confirmation = MediaBazzar.Instance.UserManager.AuthenthicateUser(employeeId, password);
                if (confirmation == null)
                {
                    return false;
                }
                else
                {
                    HttpContext.Session.SetInt32("id", confirmation.ID);
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
    }
}

