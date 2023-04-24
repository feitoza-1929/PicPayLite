using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IAccountCreateHandleAsync _accountCreateHandleAsync;
    private readonly ITransferProcessHandleAsync _transferProcessHandleAsync;

    public AccountController(
        ILogger<ClientController> logger,
        IAccountCreateHandleAsync accountCreateHandleAsync,
        ITransferProcessHandleAsync transferProcessHandleAsync)
    {
        _logger = logger;
        _accountCreateHandleAsync = accountCreateHandleAsync;
        _transferProcessHandleAsync = transferProcessHandleAsync;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequest requestData)
    {
        Result<Account> result = await _accountCreateHandleAsync.CreateAsync(requestData);
        
        return result.IsSuccess 
        ? Ok(result.Value) 
        : BadRequest(result.Errors.FirstOrDefault());
    }

    [HttpPost("Transfer")]
    public async Task<IActionResult> TransferAsync([FromBody] TransferAmountRequest requestData)
    {
        Result result = await _transferProcessHandleAsync.ProcessAsync(requestData);

        return result.IsSuccess
        ? Ok()
        : BadRequest(result.Errors.FirstOrDefault());
    }

    [HttpGet("Balance")]
    public IActionResult GetAccountBalanceAsync()
    {
        return Empty;
    }
}
