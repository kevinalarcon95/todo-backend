using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoApp.Models;

/// <summary>
/// Represents the database context for managing tasks in the application.
/// This class is used to configure and interact with the "Tasks" table in the database.
/// </summary>
/// <remarks>
/// Inherits from <see cref="DbContext"/> to provide Entity Framework Core functionality.
/// </remarks>
namespace todoApp.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}
