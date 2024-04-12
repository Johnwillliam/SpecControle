using EntityFrameworkModelV2.Config;
using EntityFrameworkModelV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkModelV2.Context
{
    public class SpecificationsDatabaseModel : DbContext
    {
        public DbSet<ATEXType> ATEXTypes { get; set; }
        public DbSet<CatType> CatTypes { get; set; }
        public DbSet<CustomOrderMotor> CustomOrderMotors { get; set; }
        public DbSet<CustomOrder> CustomOrders { get; set; }
        public DbSet<CustomOrderVentilator> CustomOrderVentilators { get; set; }
        public DbSet<CustomOrderVentilatorTest> CustomOrderVentilatorTests { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<SoundLevelType> SoundLevelTypes { get; set; }
        public DbSet<TemperatureClass> TemperatureClasses { get; set; }
        public DbSet<TemplateMotor> TemplateMotors { get; set; }
        public DbSet<TemplateVentilator> TemplateVentilators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VentilatorType> VentilatorTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationSettings.DefaultConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomOrder>().Property(p => p.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomOrderVentilator>().Property(p => p.ID).ValueGeneratedOnAdd();

            var intArrayValueConverter = new ValueConverter<IEnumerable<int>, string>(
                i => string.Join(",", i),
                s => string.IsNullOrWhiteSpace(s) ? Array.Empty<int>() : Parse(s));

            modelBuilder.Entity<CustomOrderMotor>()
                .Property(e => e.Bearings)
                .HasConversion(intArrayValueConverter);

            modelBuilder.Entity<TemplateMotor>()
                .Property(e => e.Bearings)
                .HasConversion(intArrayValueConverter);

            base.OnModelCreating(modelBuilder);
        }

        private static IEnumerable<int> Parse(string value) => value.Split(',').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
    }
}