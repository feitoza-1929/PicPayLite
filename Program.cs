using Microsoft.EntityFrameworkCore;
using PicPayLite.Application.Handlers;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.API;
using PicPayLite.Infrastructure.Configurations;
using PicPayLite.Infrastructure.Configurations.Options;
using PicPayLite.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    var configuration = builder.Configuration;

    services.AddHttpClient();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    
    // DbContext
    services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
    // Repositories
    services.AddScoped<IClientRepository, ClientRepository>();
    services.AddScoped<IAccountRepository, AccountRepository>();

    // Handles
    services.AddScoped<IClientCreateHandleAsync, ClientCreateHandleAsync>();
    services.AddScoped<IAccountCreateHandleAsync, AccountCreateHandleAsync>();
    services.AddScoped<ITransferProcessHandleAsync, TransferProcessHandleAsync>();
    services.AddScoped<ITransferCreateHandleAsync, TransferCreateHandleAsync>();
    services.AddScoped<ITransferAmountHandleAsync, TransferAmountHandleAsync>();

    services.Configure<RequestURIOptions>(
        options => configuration.GetSection(RequestURIOptions.RequestURI).Bind(options));

    // External Auth Mock
    services.AddScoped<IAuthorizationTransfer, AuthorizationTransfer>();
});

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
