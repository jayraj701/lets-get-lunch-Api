using Lets_get_lunch_Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataContextLayer.DataContext
{
    public class EFDataContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\; initial catalog=TestDB;persist security info=True;Integrated Security=SSPI;");
        }
    }
}