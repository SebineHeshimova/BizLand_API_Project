using BizLand.Core.Entity;
using BizLand.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BizLand.Data.DAL
{
    public class BizLandDbContext : IdentityDbContext
    {
        public BizLandDbContext(DbContextOptions<BizLandDbContext> options) : base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profession> Professions { get; set;}
        public DbSet<Feature> Features { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioImage> PortfolioImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
