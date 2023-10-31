using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAPI.Data.EF;
using NetAPI.Data.Entities;
using NetAPI.Helpers;
using NetAPI.Models;

namespace NetAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AccountsController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public AccountsController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var check = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (check != null) return BadRequest(new ApiBadRequestResponse($"Email {request.Email} is already registered"));
        string id = Guid.NewGuid().ToString();
        Account account = new Account()
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = MD5Encrypt.Encrypt(request.Password!),
            CreatedDate = DateTime.Now
        };
        await _context.Accounts.AddAsync(account);
        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return CreatedAtAction(nameof(GetById), new { id = id }, request);
        }
        else
        {
            return BadRequest(new ApiBadRequestResponse("Create account failed"));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
            return NotFound(new ApiNotFoundResponse($"Cannot found account with id: {id}"));

        AccountViewModel accountViewModel = CreateAccountViewModel(account);

        return Ok(accountViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
            return NotFound(new ApiNotFoundResponse($"Cannot found account with id: {id}"));

        AccountViewModel accountViewModel = CreateAccountViewModel(account);

        _context.Accounts.Remove(account);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return Ok(accountViewModel);
        }
        return BadRequest(new ApiBadRequestResponse("Delete account failed"));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (account == null)
            return NotFound(new ApiNotFoundResponse($"Account with email: {request.Email} is not found"));
        if (MD5Encrypt.Encrypt(request.Password!) == account.PasswordHash)
        {
            return Ok(CreateAccountViewModel(account));
        }
        else return BadRequest(new ApiBadRequestResponse("Password is not math"));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _context.Accounts.ToListAsync();
        var result = accounts.Select(x => CreateAccountViewModel(x)).ToList();
        return Ok(result);
    }

    private static AccountViewModel CreateAccountViewModel(Account account)
    {
        return new AccountViewModel()
        {
            Id = account.Id,
            FirstName = account.FirstName,
            LastName = account.LastName,
            Email = account.Email,
            CreatedDate = account.CreatedDate
        };
    }
}
