using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TodolistApp.Models;

namespace TodolistApp.Migrations
{
    [DbContext(typeof(TodolistAppContext))]
    [Migration("20170407004441_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodolistApp.Models.Todolistitem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Status");

                    b.Property<string>("TimeTaken");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Todolistitem");
                });
        }
    }
}
