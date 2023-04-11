using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PicPayLite.Application.Handlers;
using PicPayLite.Domain.Clients;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientCreateHandleAsync _clientCreateHandleAsync;

    public ClientController(
        ILogger<ClientController> logger,
        IClientCreateHandleAsync clientCreateHandleAsync)
    {
        _logger = logger;
        _clientCreateHandleAsync = clientCreateHandleAsync;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateClientAsync([FromBody] CreateClientRequest requestData)
    {
        Result<Client> result = await _clientCreateHandleAsync.CreateAsync(requestData);

        return result.IsSuccess
        ? Ok()
        : BadRequest(result.Errors.First());
    }

    [HttpGet("Token")]
    public IActionResult GetClientTokenAsync()
    {
        return Empty;
    }
}
