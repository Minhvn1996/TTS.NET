using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using NetAPI.Data.EF;
using NetAPI.Data.Entities;
using NetAPI.Helpers;
using NetAPI.Models;

namespace NetAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductsController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public ProductsController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var checkProduct = await _context.Products.FirstOrDefaultAsync(x => x.Name == request.Name);
        if (checkProduct != null) return BadRequest(new ApiBadRequestResponse($"Product {request.Name} is already registered"));

        var checkCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
        if (checkCategory == null) return BadRequest(new ApiBadRequestResponse($"Category {request.CategoryId} does not exist"));

        Product product = new Product()
        {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Status = true
        };
        await _context.Products.AddAsync(product);
        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, request);
        }
        else
        {
            return BadRequest(new ApiBadRequestResponse("Create product failed"));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
            return NotFound(new ApiNotFoundResponse($"Cannot found product with id: {id}"));
        var productViewModel = new ProductViewModel()
        {
            Id = product.Id,
            CategoryName = product.Category!.Name,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Status = product.Status,
        };
        return Ok(productViewModel);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = from p in _context.Products
                    join c in _context.Categories on p.CategoryId equals c.Id
                    select new { p, c };

        var totalRecords = await query.CountAsync();

        var items = await query.Select(u => new ProductViewModel()
        {
            Id = u.p.Id,
            CategoryName = u.c.Name,
            Name = u.p.Name,
            Description = u.p.Description,
            Price = u.p.Price,
            Status = u.p.Status,
        })
            .ToListAsync();

        return Ok(items);
    }

    [HttpGet("paging")]
    public async Task<IActionResult> GetAllPaging(string filter, int? categoryId, int pageIndex = 1, int pageSize = 10)
    {
        var query = from p in _context.Products
                    join c in _context.Categories on p.CategoryId equals c.Id
                    select new { p, c };

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.p.Name != null && x.p.Name.Contains(filter));
        }

        if (categoryId.HasValue)
        {
            query = query.Where(x => x.p.CategoryId == categoryId.Value);
        }

        var totalRecords = await query.CountAsync();

        var items = await query.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new ProductViewModel()
            {
                Id = u.p.Id,
                CategoryName = u.c.Name,
                Name = u.p.Name,
                Description = u.p.Description,
                Price = u.p.Price,
                Status = u.p.Status,
            })
            .ToListAsync();

        var pagination = new Pagination<ProductViewModel>
        {
            PageSize = pageSize,
            PageIndex = pageIndex,
            Items = items,
            TotalRecords = totalRecords,
        };
        return Ok(pagination);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound(new ApiNotFoundResponse($"Cannot found product with id: {id}"));

        _context.Products.Remove(product);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            return Ok(product);
        }
        return BadRequest(new ApiBadRequestResponse("Delete product failed"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var product = await _context.Products.FindAsync(id);
        var check = await _context.Products.FirstOrDefaultAsync(x => x.Name == request.Name && x.Id != id);

        if (check != null)
        {
            return BadRequest(new ApiBadRequestResponse($"Product {request.Name} is already registered"));
        }

        if (product == null)
        {
            return NotFound(new ApiNotFoundResponse($"Cannot find product with id: {id}"));
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Status = request.Status;
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportData(List<ProductRequest> dataImport)
    {
        if (dataImport == null) return BadRequest(new ApiBadRequestResponse("Import list is empty"));

        List<Product> dataList = new List<Product>();
        foreach (var item in dataImport)
        {
            Product product = new Product()
            {
                CategoryId = item.CategoryId,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Status = item.Status
            };
            dataList.Add(product);
        }

        List<Product> listProduct = await _context.Products.ToListAsync();
        List<string> namesToDelete = listProduct.Select(p => p.Name!).ToList();

        var categories = await _context.Categories.AsNoTracking().ToListAsync();
        List<int> idsToDelete = categories.Select(p => p.Id).ToList();

        dataList.RemoveAll(p => !idsToDelete.Contains(p.CategoryId));
        dataImport.RemoveAll(p => !idsToDelete.Contains(p.CategoryId));

        dataList.RemoveAll(p => namesToDelete.Contains(p.Name!));
        dataImport.RemoveAll(p => namesToDelete.Contains(p.Name!));


        await _context.Products.AddRangeAsync(dataList);
        await _context.SaveChangesAsync();

        return Ok(dataList);
    }
}