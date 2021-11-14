using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using eplayout.API.Data;
using Microsoft.EntityFrameworkCore;

namespace TournamentApp.Pages
{
    public class AdminLoginModel : PageModel
    {
        private readonly DataContext context;

        public AdminLoginModel(DataContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            var user = await context.AdminUsers.FirstOrDefaultAsync(x => x.UserName == UserName);
            var passwordHasher = new PasswordHasher<string>();
            if (passwordHasher.VerifyHashedPassword("eplayoutsalt", user.Password, Password) == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/Admin/Index");
            }
           
            Message = "Invalid attempt";
            return Page();
        }
    }
}

