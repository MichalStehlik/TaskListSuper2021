using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskListSuper2021.Data;
using TaskListSuper2021.Models;
using TaskListSuper2021.ViewModels;

namespace TaskListSuper2021.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TaskListSuper2021.Data.ApplicationDbContext _context;
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public CreateModel(TaskListSuper2021.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email");
        ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public TaskIM TaskItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var newTask = new TaskItem
            {
                Name = TaskItem.Name,
                Description = TaskItem.Description,
                FinishDate = TaskItem.FinishDate,
                Finished = TaskItem.Finished,
                AuthorId = userId,
                ReceiverId = TaskItem.ReceiverId,
                Created = DateTime.Now,
            };
            try
            {
                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();
                SuccessMessage = "A new task was created.";
            }
            catch
            {
                ErrorMessage = "There was an error.";
            }

            return RedirectToPage("./TasksMade");
        }
    }
}
