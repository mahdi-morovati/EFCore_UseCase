using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EfCore.Infrastructure.EfCore;

public class EfContextFactory: IDesignTimeDbContextFactory<EfContext>
{
    public EfContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EfContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=EFCoreProject;User Id=sa;Password=Mahdi#7171;TrustServerCertificate=True");
        
        return new EfContext(optionsBuilder.Options);
        
        // Set up configuration sources.
        // var configuration = new ConfigurationBuilder()
        //     .SetBasePath("/EFCore_UseCase/")
        //     .AddJsonFile("appsettings.json")
        //     .Build();
        //
        // var connectionString = configuration.GetConnectionString("DefaultConnection");
        //
        // var optionsBuilder = new DbContextOptionsBuilder<EfContext>();
        // optionsBuilder.UseSqlServer(connectionString);
        //
        // return new EfContext(optionsBuilder.Options);
    }
}