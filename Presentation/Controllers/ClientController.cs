using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Clients;
using PicPayLite.Infrastructure;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientCreateHandleAsync _clientCreateHandleAsync;
    private readonly IClientTokenHandleAsync _clientTokenHandleAsync;
    private readonly ApplicationDbContext _dbContext;
    
    public ClientController(
        ILogger<ClientController> logger,
        IClientCreateHandleAsync clientCreateHandleAsync,
         IClientTokenHandleAsync clientTokenHandleAsync,
        ApplicationDbContext dbContext)
    {
        _logger = logger;
        _clientCreateHandleAsync = clientCreateHandleAsync;
        _clientTokenHandleAsync = clientTokenHandleAsync;
        _dbContext = dbContext;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateClientAsync([FromBody] CreateClientRequest requestData)
    {
        if(await _dbContext.Database.CanConnectAsync())
            Console.WriteLine("connected to database");
            
        Result result = 
            await _clientCreateHandleAsync.CreateAsync(requestData);

        return result.IsSuccess
        ? Ok()
        : BadRequest(result.Errors.FirstOrDefault());
    }

    [HttpGet("{document}/token")]
    public async Task<IActionResult> GetClientTokenAsync(string document)
    {
        Result<string> result =
            await _clientTokenHandleAsync.CreateAsync(document);

        return result.IsSuccess 
        ? Ok(result.Value)
        : BadRequest(result.Errors.FirstOrDefault());
    }
}
