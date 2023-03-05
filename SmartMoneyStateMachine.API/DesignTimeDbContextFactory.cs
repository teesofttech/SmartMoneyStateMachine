using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using SmartMoneyStateMachine.API.Infrastructure;

namespace SmartMoneyStateMachine.API
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StateMachineContext>
    {
        public StateMachineContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<StateMachineContext>();
            var connectionString = configuration.GetConnectionString("Default");
            builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("SmartMoneyStateMachine.API"));
            return new StateMachineContext(builder.Options);
        }
    }
}
