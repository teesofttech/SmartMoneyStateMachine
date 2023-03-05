using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using SmartMoneyStateMachine.API.Infrastructure;
using SmartMoneyStateMachine.Shared;
using System.Reflection;
using static MassTransit.Logging.LogCategoryName;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<StateMachineContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Default")));

builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumers(Assembly.GetExecutingAssembly());
    configure.SetKebabCaseEndpointNameFormatter();
    configure.AddSagaStateMachine<CustomerStateMachine, CustomerForgotPasswordState>()
    .EntityFrameworkRepository(options =>
    {
        options.ConcurrencyMode = ConcurrencyMode.Optimistic; // or use Optimistic, which requires RowVersion

        options.ExistingDbContext<StateMachineContext>();
        //options.AddDbContext<DbContext, StateMachineContext>((provider, builder) =>
        //{
        //    builder.UseSqlServer(configuration.GetConnectionString("Default"));
        //});
    });


    configure.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
        cfg.Host((configuration.GetSection("MassTransitConfig:Host").Value), (configuration.GetSection("MassTransitConfig:VirtualHost").Value),
                 h =>
                 {
                     h.Username(configuration.GetSection("MassTransitConfig:Username").Value);
                     h.Password(configuration.GetSection("MassTransitConfig:Password").Value);
                 }
       );

    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransitHostedService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
