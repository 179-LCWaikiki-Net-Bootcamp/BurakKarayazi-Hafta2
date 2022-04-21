using Microsoft.EntityFrameworkCore;
using GenericCrud.Models;

namespace GenericCrud.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().ToTable("ToDoItems");
            modelBuilder.Entity<ToDoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<ToDoItem>().Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Note>().HasKey(x => x.Id);
            modelBuilder.Entity<Note>().Property(x => x.Id).ValueGeneratedNever();
        }

    }
}
