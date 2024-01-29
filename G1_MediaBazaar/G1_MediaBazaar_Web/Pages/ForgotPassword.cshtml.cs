using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary;
using StoreLibrary;
using System.Security.Cryptography;
using UserLibrary;

namespace G1_MediaBazaar_Web.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public string inputEmail { get; set; }
        [BindProperty]
        public string errorMessage { get; set; }
        private static readonly string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string Digits = "0123456789";
        private static readonly string SpecialCharacters = "!@#$%^&*()-=_+[]{}|;:,.<>/?";
        public static string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeDigits, bool includeSpecialCharacters)
        {
            string validCharacters = "";

            if (includeUppercase)
                validCharacters += UppercaseLetters;
            if (includeLowercase)
                validCharacters += LowercaseLetters;
            if (includeDigits)
                validCharacters += Digits;
            if (includeSpecialCharacters)
                validCharacters += SpecialCharacters;

            char[] password = new char[length];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                crypto.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    int index = randomBytes[i] % validCharacters.Length;
                    password[i] = validCharacters[index];
                }
            }

            return new string(password);
        }
        public void OnGet()
        {
            TempData["ErrorMessage"] = string.Empty;
        }

        public IActionResult OnPost()
        {
            try
            {
                User tempUser = MediaBazzar.Instance.UserManager.GetUser(inputEmail);
                if (tempUser != null)
                {
                    errorMessage = "Email not registered";
                    return Page();
                }
                //random pwd
                tempUser.Password = GeneratePassword(10, true, true, true, false);
                MediaBazzar.Instance.UserManager.UpdateUser(tempUser.ID, tempUser);
                MediaBazzar.Instance.UserManager.SendEmail(inputEmail, $"Your new password is {tempUser.Password}. Please log in and update your password in your profile", "Your new recovery password");
                return RedirectToPage("/LogInPage");
            }
            catch (Exception ex)
            {
                errorMessage = "Email invalid";
                return Page();
            }
            
        }
    }
}
