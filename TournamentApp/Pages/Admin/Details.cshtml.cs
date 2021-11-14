using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Models;
using eplayout.API.Data;

namespace TournamentApp.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly eplayout.API.Data.DataContext _context;

        public DetailsModel(eplayout.API.Data.DataContext context)
        {
            _context = context;
        }

        public Registration Registration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Registration = await _context.Registrations.FirstOrDefaultAsync(m => m.Id == id);

            if (Registration == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
