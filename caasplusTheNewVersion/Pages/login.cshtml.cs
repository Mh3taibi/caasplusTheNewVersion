using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace caasplusTheNewVersion.Pages
{

    public class loginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public loginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        
        private int getUserType(GeneralEnums.UsersTypes type )
        {
            switch (type)
            {
                case GeneralEnums.UsersTypes.client:
                    return 0;

                case GeneralEnums.UsersTypes.provider:
                    return 1;

                case GeneralEnums.UsersTypes.admin:
                    return 2;

                case GeneralEnums.UsersTypes.manger:
                    return 3;

                default: return 4;

            }
        }
         
           

            public void OnGet()
            {
                // This method is called when the page is first loaded
            }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == UserName);

            if (user != null && VerifyPassword(Password, user.passwordHashed))
            {
                 if (user.UserType == 0) 
                
                {
                    return RedirectToPage("/clientDashboard"); // Redirect to home page or dashboard                
                } 
                else if (user.UserType == 1)
                {
                    return RedirectToPage("/Index");
                }
                else if (user.UserType == 2)
                {
                    return RedirectToPage("/Index");
                }
                else if (user.UserType == 3)
                {
                    return RedirectToPage("/Index");
                }
                 else
                {
                    ErrorMessage = "«”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                    return Page();
                }
            }
            else
            {
                ErrorMessage = "«”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                return Page();
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hashedInputPassword = GetHash(sha256Hash, inputPassword);
                return hashedInputPassword == storedHash;
            }
        }

        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    


     }
    }


