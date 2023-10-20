using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CsvSeederWebAPI.Model
{
    public class TestDemoDbContext : DbContext
    {
        public TestDemoDbContext(DbContextOptions<TestDemoDbContext> options)
       : base(options)
        {
        }
        public DbSet<CsvData> CsvData { get; set; }
    }
}
