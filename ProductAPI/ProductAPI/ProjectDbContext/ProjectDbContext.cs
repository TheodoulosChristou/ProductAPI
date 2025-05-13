using Microsoft.EntityFrameworkCore;
using ProductAPI.Configurations;
using ProductAPI.Entities;

namespace ProductAPI.ProjectDbContext
{
    public class ProjectDbContext :DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options) 
        {
            
        }

        public DbSet<Product> Product {  get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<User> User {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
