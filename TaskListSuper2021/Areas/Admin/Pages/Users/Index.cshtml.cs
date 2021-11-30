using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskListSuper2021.Data;
using TaskListSuper2021.Models;

namespace TaskListSuper2021.Areas.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;

        public IndexModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
