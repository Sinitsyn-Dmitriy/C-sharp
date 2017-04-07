using System;
using System.ComponentModel.DataAnnotations;

namespace TodolistApp.Models
{
    public class Todolistitem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string TimeTaken { get; set; }
    }
}