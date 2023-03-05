using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMoneyStateMachine.Shared;
using System.Reflection;

namespace SmartMoneyStateMachine.API.Infrastructure
{
    public class StateMachineContext : DbContext
    {
        public StateMachineContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public StateMachineContext(DbContextOptions<StateMachineContext> options) : base(options)
        {

        }
        public DbSet<CustomerForgotPasswordState> CustomerForgotPasswordState { get; set; }
    }

    public class SagaStateMap : IEntityTypeConfiguration<CustomerForgotPasswordState>
    {
        public void Configure(EntityTypeBuilder<CustomerForgotPasswordState> builder)
        {

        }
    }
}
