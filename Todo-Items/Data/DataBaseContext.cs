using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo_Items.Models;

namespace Todo_Items.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext (DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Todo_Items.Models.TodoItemsEntry> TodoItemsEntry { get; set; } = default!;
    }
}
