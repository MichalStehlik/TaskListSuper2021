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
    public class DetailsModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;

        public DetailsModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
