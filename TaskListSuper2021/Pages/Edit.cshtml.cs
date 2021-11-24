using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskListSuper2021.Data;
using TaskListSuper2021.Models;
using TaskListSuper2021.ViewModels;

namespace TaskListSuper2021.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;

        public EditModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskIM TaskItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.Tasks
                .Include(t => t.Author)
                .Include(t => t.Receiver)
                .Select(t => new TaskIM { TaskId = t.TaskId, Name = t.Name, Description = t.Description, FinishDate = t.FinishDate, Finished = t.Finished, ReceiverId = t.ReceiverId})
                .FirstOrDefaultAsync(m => m.TaskId == id);

            if (TaskItem == null)
            {
                return NotFound();
            }
           ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email");
           ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var item = _context.Tasks.SingleOrDefault(t => t.TaskId == TaskItem.TaskId);
            item.Name = TaskItem.Name;
            item.Description = TaskItem.Description;
            item.FinishDate = TaskItem.FinishDate;
            item.Finished = TaskItem.Finished;
            item.ReceiverId = TaskItem.ReceiverId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(TaskItem.TaskId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./TasksMade");
        }

        private bool TaskItemExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
