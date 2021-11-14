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
    public class IndexModel : PageModel
    {
        private readonly eplayout.API.Data.DataContext _context;

        public IndexModel(eplayout.API.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Registration> Registration { get;set; }

        public async Task OnGetAsync()
        {
            Registration = await _context.Registrations.ToListAsync();
        }
    }
}
