using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DeleteModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;

        public DeleteModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.Tasks
                .Include(t => t.Author)
                .Include(t => t.Receiver).FirstOrDefaultAsync(m => m.TaskId == id);

            if (TaskItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.Tasks.FindAsync(id);

            if (TaskItem != null)
            {
                _context.Tasks.Remove(TaskItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./TasksMade");
        }
    }
}
