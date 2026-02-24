using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finandina_Persistence.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseSqlServer(
            @"Server=localhost;
              Database=finandinaPruebaTecnica;
              User Id=FinandinaTest;
              Password=QWaszx12/*;
              TrustServerCertificate=True;");

            return new ApplicationContext(builder.Options);
        }
    }
}
