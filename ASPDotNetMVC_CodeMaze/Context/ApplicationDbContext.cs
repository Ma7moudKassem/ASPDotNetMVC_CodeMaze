﻿using ASPDotNetMVC_CodeMaze.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetMVC_CodeMaze;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
}