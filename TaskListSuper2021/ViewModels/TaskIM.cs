using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskListSuper2021.Models;

namespace TaskListSuper2021.ViewModels
{
    public class TaskIM
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
        public bool Finished { get; set; }

        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
        [Required]
        public string ReceiverId { get; set; }
    }
}
