using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Domain.ValueObjects;
using PicPayLite.Presentation.RequestsPattern;
using PicPayLite.Presentation.ResponsePattern;

namespace PicPayLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IAccountCreateHandleAsync _accountCreateHandleAsync;
    private readonly IAccountGetBalanceHandleAsync _accountGetBalanceHandleAsync;
    private readonly IAccountGetHandleAsync _accountGetHandleAsync;
    private readonly ITransferProcessHandleAsync _transferProcessHandleAsync;

    public AccountController(
        ILogger<ClientController> logger,
        IAccountCreateHandleAsync accountCreateHandleAsync,
        IAccountGetBalanceHandleAsync accountGetBalanceHandleAsync,
        IAccountGetHandleAsync accountGetHandleAsync,
        ITransferProcessHandleAsync transferProcessHandleAsync)
    {
        _logger = logger;
        _accountCreateHandleAsync = accountCreateHandleAsync;
        _accountGetBalanceHandleAsync = accountGetBalanceHandleAsync;
        _accountGetHandleAsync = accountGetHandleAsync;
        _transferProcessHandleAsync = transferProcessHandleAsync;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequest requestData)
    {
        Result<Account> result = 
            await _accountCreateHandleAsync.CreateAsync(requestData);

        return result.IsSuccess 
        ? Created("", AccountResponse.Create(result.Value)) 
        : BadRequest(ErrorResponse.Create(result.Errors.First()));
    }

    [Authorize]
    [HttpPost("transfer")]
    public async Task<IActionResult> TransferAsync([FromBody] TransferAmountRequest requestData)
    {
        Result<Transfer> result = 
            await _transferProcessHandleAsync.ProcessAsync(requestData);

        return result.IsSuccess
        ? Created("", TransferResponse.Create(result.Value))
        : BadRequest(ErrorResponse.Create(result.Errors.First()));
    }

    [Authorize]
    [HttpGet("{clientDocument}")]
    public async Task<IActionResult> GetAccountBalanceAsync(string clientDocument)
    {
        Result<Account> result =
            await _accountGetHandleAsync.GetAsync(clientDocument);

        return result.IsSuccess
            ? Ok(AccountResponse.Create(result.Value))
            : BadRequest(ErrorResponse.Create(result.Errors.First()));
    }

    [Authorize]
    [HttpGet("{accountNumber}/balance")]
    public async Task<IActionResult> GetAccountBalanceAsync(int accountNumber)
    {
        Result<Balance> result = 
            await _accountGetBalanceHandleAsync.GetAsync(accountNumber);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(ErrorResponse.Create(result.Errors.First()));
    }
}
