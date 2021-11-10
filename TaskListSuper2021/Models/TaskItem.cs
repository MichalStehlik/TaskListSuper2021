using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskListSuper2021.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
        public bool Finished { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        [Required]
        public string AuthorId { get; set; }
        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
        [Required]
        public string ReceiverId { get; set; }
    }
}
