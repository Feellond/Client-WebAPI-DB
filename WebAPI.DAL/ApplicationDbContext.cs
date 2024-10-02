using Microsoft.EntityFrameworkCore;
using WebAPI.DAL.Const;
using WebAPI.DAL.Entities.Database;

namespace WebAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pharma.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateDefaultData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public static void CreateDefaultData(ModelBuilder builder)
        {
            builder.Entity<Manufacturer>().HasData(
            [
                new Manufacturer
                {
                    Id = 1,
                    Name = "Завод Жизни",
                    Country = "Россия",
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Завод Сомнений",
                    Country = "Нидерланды",
                },
            ]);

            builder.Entity<Product>().HasData(
            [
                new Product 
                {
                    Id = 1, 
                    Name = "Хорошоцин",
                    Shape = (int)ShapeEnum.Tablets,
                    Dosage = "Только взрослым по 1-2 таблетки в день.",
                    ReleaseDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(3),
                    ManufacturerId = 1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Плохоцин",
                    Shape = (int)ShapeEnum.Liquid,
                    Dosage = "Пей и пожалей.",
                    ReleaseDate = DateTime.Now.AddDays(-2),
                    ExpirationDate = DateTime.Now.AddDays(-1),
                    ManufacturerId = 2,
                },
            ]);
        }
    }
}
