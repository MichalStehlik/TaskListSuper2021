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

            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            TaskItem = await _context.Tasks
                .Include(t => t.Author)
                .Include(t => t.Receiver).FirstOrDefaultAsync(m => m.TaskId == id);

            if (TaskItem.ReceiverId != userId && TaskItem.AuthorId != userId)
            {
                return Unauthorized();
            }
            if (TaskItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
