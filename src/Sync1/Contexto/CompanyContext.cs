using Microsoft.EntityFrameworkCore;
using Sync1.Model;

namespace Sync1.Contexto
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) 
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

      
    }
}
