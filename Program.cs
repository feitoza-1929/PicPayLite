using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PicPayLite.Application.Handlers;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.API;
using PicPayLite.Infrastructure.Authentication;
using PicPayLite.Infrastructure.Cache;
using PicPayLite.Infrastructure.ConfigurationOptionsSetup;
using PicPayLite.Infrastructure.Options;
using PicPayLite.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("SqlServer")));
// Redis
builder.Services.AddStackExchangeRedisCache(
    options => options.Configuration = builder.Configuration.GetConnectionString("Redis"));
        
// Repositories
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();

// Cached Repositories
builder.Services.AddTransient<CachedAccountRepository>();

// Handlers
builder.Services.AddScoped<IClientCreateHandleAsync, ClientCreateHandleAsync>();
builder.Services.AddScoped<IClientTokenHandleAsync, ClientTokenHandleAsync>();
builder.Services.AddScoped<IAccountCreateHandleAsync, AccountCreateHandleAsync>();
builder.Services.AddScoped<IAccountGetBalanceHandleAsync, AccountGetBalanceHandleAsync>();
builder.Services.AddScoped<IAccountGetHandleAsync, AccountGetHandleAsync>();
builder.Services.AddScoped<ITransferProcessHandleAsync, TransferProcessHandleAsync>();
builder.Services.AddScoped<ITransferCreateHandleAsync, TransferCreateHandleAsync>();
builder.Services.AddScoped<ITransferAmountHandleAsync, TransferAmountHandleAsync>();

    

builder.Services.Configure<RequestURIOptions>(
    options => configuration.GetSection(RequestURIOptions.RequestURI).Bind(options));

// External Auth Mock
builder.Services.AddScoped<IAuthorizationTransfer, AuthorizationTransfer>();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();


var app = builder.Build();

DatabaseManagement.MigrationInitialisation(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
