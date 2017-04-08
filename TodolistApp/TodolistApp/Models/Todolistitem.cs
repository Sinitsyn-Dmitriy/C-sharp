using System;
using System.ComponentModel.DataAnnotations;

namespace TodolistApp.Models
{
    public class Todolistitem
    {
        public int ID { get; set; }

        [StringLength(250, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Category { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [StringLength(250, MinimumLength = 1)]
        public string Status { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Display(Name = "Time Taken")]
        public string TimeTaken { get; set; }
    }
}