using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskListSuper2021.Data;
using TaskListSuper2021.Models;

namespace TaskListSuper2021.Areas.Admin.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;

        public IndexModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItem { get;set; }

        public async Task OnGetAsync()
        {
            TaskItem = await _context.Tasks
                .Include(t => t.Author)
                .Include(t => t.Receiver).ToListAsync();
        }
    }
}
