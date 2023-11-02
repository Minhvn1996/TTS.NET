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

public class CategoriesController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public CategoriesController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var check = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.Name);
        if (check != null) return BadRequest(new ApiBadRequestResponse($"Category {request.Name} is already registered"));

        Category category = new Category()
        {
            Name = request.Name
        };
        await _context.Categories.AddAsync(category);
        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, request);
        }
        else
        {
            return BadRequest(new ApiBadRequestResponse("Create category failed"));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound(new ApiNotFoundResponse($"Cannot found category with id: {id}"));
        return Ok(category);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound(new ApiNotFoundResponse($"Cannot found category with id: {id}"));

        _context.Categories.Remove(category);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return Ok(category);
        }
        return BadRequest(new ApiBadRequestResponse("Delete category failed"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] CategoryRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var category = await _context.Categories.FindAsync(id);
        var check = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.Name && x.Id != id);

        if (check != null)
        {
            return BadRequest(new ApiBadRequestResponse($"Category {request.Name} is already registered"));
        }

        if (category == null)
        {
            return NotFound(new ApiNotFoundResponse($"Cannot find category with id: {id}"));
        }

        category.Name = request.Name;
        await _context.SaveChangesAsync();
        return Ok(category);
    }
}
