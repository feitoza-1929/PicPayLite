using Microsoft.EntityFrameworkCore;
using PicPayLite.Application.Handlers;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.API;
using PicPayLite.Infrastructure.Options;
using PicPayLite.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
// Repositories
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();

// Handles
builder.Services.AddScoped<IClientCreateHandleAsync, ClientCreateHandleAsync>();
builder.Services.AddScoped<IClientTokenHandleAsync, ClientTokenHandleAsync>();
builder.Services.AddScoped<IAccountCreateHandleAsync, AccountCreateHandleAsync>();
builder.Services.AddScoped<ITransferProcessHandleAsync, TransferProcessHandleAsync>();
builder.Services.AddScoped<ITransferCreateHandleAsync, TransferCreateHandleAsync>();
builder.Services.AddScoped<ITransferAmountHandleAsync, TransferAmountHandleAsync>();

    

builder.Services.Configure<RequestURIOptions>(
    options => configuration.GetSection(RequestURIOptions.RequestURI).Bind(options));

// External Auth Mock
builder.Services.AddScoped<IAuthorizationTransfer, AuthorizationTransfer>();

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
