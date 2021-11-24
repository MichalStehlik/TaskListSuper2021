using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskListSuper2021.Data;
using TaskListSuper2021.Models;

namespace TaskListSuper2021.Pages
{
    [Authorize]
    public class TasksMadeModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;

        public TasksMadeModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItem { get;set; }

        public async Task OnGetAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            TaskItem = await _context.Tasks
                .Include(t => t.Author)
                .Include(t => t.Receiver)
                .Where(t => t.AuthorId == userId)
                .ToListAsync();
        }
    }
}
