using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodolistApp.Models
{
    public class TodolistAppContext : DbContext
    {
        public TodolistAppContext (DbContextOptions<TodolistAppContext> options)
            : base(options)
        {
        }

        public DbSet<TodolistApp.Models.Todolistitem> Todolistitem { get; set; }
    }
}
