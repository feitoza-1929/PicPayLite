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
    private readonly ApplicationDbContext _dbContext;

    public ClientController(
        ILogger<ClientController> logger,
        IClientCreateHandleAsync clientCreateHandleAsync,
        ApplicationDbContext dbContext)
    {
        _logger = logger;
        _clientCreateHandleAsync = clientCreateHandleAsync;
        _dbContext = dbContext;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateClientAsync([FromBody] CreateClientRequest requestData)
    {
        Result result = await _clientCreateHandleAsync.CreateAsync(requestData);

        return result.IsSuccess
        ? Ok()
        : BadRequest(result.Errors.FirstOrDefault());
    }

    [HttpGet("Token")]
    public IActionResult GetClientTokenAsync()
    {
        var result = await _clientTokenHandleAsync.CreateAsync();
        return Ok(result.value);
    }
}
