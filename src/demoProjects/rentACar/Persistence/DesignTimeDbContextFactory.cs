using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts;

namespace Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
{
    public BaseDbContext CreateDbContext(string[] args)
    {
        ConfigurationManager configManager = new ConfigurationManager();
        configManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
        configManager.AddJsonFile("appsettings.json");
        
        var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();
        optionsBuilder.UseSqlServer(configManager.GetConnectionString("CleanArchitectureRentACarConnectionString"));

        return new(optionsBuilder.Options);
    }
}