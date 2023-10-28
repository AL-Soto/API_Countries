using API_Sat_2023_Primer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Sat_2023_Primer.DAL
{
    public class DataBaseContext : DbContext 
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //evita nombres duplicados 
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId" ).IsUnique(); //Indices compuestos 

        }
        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }
    }
}
