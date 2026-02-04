using FikretMungan.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FikretMungan.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders{ get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                password = "xyz123456"
            });
        }
       

    }
}
