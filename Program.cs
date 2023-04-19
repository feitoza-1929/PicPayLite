using Microsoft.EntityFrameworkCore;
using PicPayLite.Application.Handlers;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.API;
using PicPayLite.Infrastructure.Options;
using PicPayLite.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    var configuration = builder.Configuration;

    // DbContext
    services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    services.AddHttpClient();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddRouting(options => options.LowercaseUrls = true);
        
    // Repositories
    services.AddTransient<IClientRepository, ClientRepository>();
    services.AddTransient<IAccountRepository, AccountRepository>();
    services.AddTransient<ITransferRepository, TransferRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
