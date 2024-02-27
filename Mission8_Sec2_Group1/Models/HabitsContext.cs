using Microsoft.EntityFrameworkCore;
using CategoryModel.Models;
using TaskModel.Models;


namespace HabitContext.Models
{
    public class HabitsContext : DbContext
    {
        public HabitsContext(DbContextOptions<HabitsContext> options) : base(options) 
        { }

        public DbSet<TaskModel.Models.Task> Tasks { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Home" }
                );
        }
    }
}
