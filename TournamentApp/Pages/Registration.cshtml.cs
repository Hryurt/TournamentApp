using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using eplayout.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TournamentApp.Models;

namespace TournamentApp.Pages
{
    public class RegistrationModel : PageModel
    {
        public string Message = "Default";
        private readonly DataContext _context;

        public RegistrationModel(DataContext context)
        {
            this._context = context;
        }
        public void OnGet()
        {
            Message = "Default";
        }
        public async Task<IActionResult> OnPost()
        {
            Registration newRegistration = new Registration
            {
                Name = Request.Form["name"],
                Surname = Request.Form["surname"],
                Email = Request.Form["email"],
                TeamCheck = Request.Form["teamCheck"],
                TeamName = Request.Form["teamName"],
                Game = Request.Form["game"],
                DiscordId = Request.Form["discordId"],
                RulesCheck = Request.Form["rulesCheck"],
                CreatedAt = DateTime.Now
            };

            _context.Registrations.Add(newRegistration);
            await _context.SaveChangesAsync();

            Message = "Success";

            return Page();
        }
    }
}
