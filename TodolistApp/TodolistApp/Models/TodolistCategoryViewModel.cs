using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TodolistApp.Models
{
    public class TodolistCategoryViewModel
    {
        public List<Todolistitem> todolist;
        public SelectList categories;
        public string todolistCategory { get; set; }
    }
}








