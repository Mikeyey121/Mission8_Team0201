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

        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                    new Categories { CategoryId = 1, CategoryName = "Home" }
                );
        }
    }
}
