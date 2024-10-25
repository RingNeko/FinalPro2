using FinalPro1.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalPro1.Data
{
    public class CmsContext : DbContext
    {
            public CmsContext(DbContextOptions<CmsContext> options) : base(options)
            {
            }
            public DbSet<City> TableCOUNTYANDCITYs1111757 { get; set; }
            public DbSet<Store> TableSTOREs1111757 { get; set; }
            public DbSet<Member> TableMEMBERSs1111757 { get; set; }
            public DbSet<Discount> TableDISCOUNTs1111757 { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            }
    }
    
}
