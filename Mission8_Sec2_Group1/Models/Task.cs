﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CategoryModel.Models;

namespace TaskModel.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
