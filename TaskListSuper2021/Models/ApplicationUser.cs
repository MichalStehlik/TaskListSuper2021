using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskListSuper2021.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TaskItem> TasksCreated { get; set; }
        public ICollection<TaskItem> TasksGiven { get; set; }
    }
}
