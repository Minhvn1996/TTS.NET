using NetAPI.Data.EF;
using NetAPI.Data.Entities;
using NetAPI.Models.Enum;

namespace NetAPI.Data.EF;

public class DbInitializer
{
    private readonly ApplicationDBContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DbInitializer(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public string GetResourceDirectoryPath()
    {
        return _webHostEnvironment.WebRootPath;
    }
    public async Task Seed()
    {
        if (!_context.Accounts.Any())
        {
            var account1 = new Account
            {
                Id = new Guid("3375b35a-9bcc-4b49-a1ed-611a38a607d2").ToString(),
                FirstName = "Nguyen Van",
                LastName = "A",
                PasswordHash = Helpers.MD5Encrypt.Encrypt("Password@123"),
                Email = "nguyenvana@gmail.com",
                CreatedDate = DateTime.Now,
                Role = Role.ADMINISTRATOR
            };

            var account2 = new Account
            {
                Id = new Guid("3375b35a-9bcc-4b49-a1ed-611a38a607d3").ToString(),
                FirstName = "Le Thi",
                LastName = "B",
                PasswordHash = Helpers.MD5Encrypt.Encrypt("Password@123"),
                Email = "lethib@gmail.com",
                CreatedDate = DateTime.Now,
                Role = Role.USER
            };
            _context.Accounts.AddRange(new List<Account>() { account1, account2 });
            await _context.SaveChangesAsync();
        }

        if (!_context.Customers.Any())
        {
            var customer1 = new Customer
            {
                Name = "A Dat",
                Sdt = "+84 123456789"
            };

            var customer2 = new Customer
            {
                Name = "A Minh",
                Sdt = "+84 123456789"
            };

            var customer3 = new Customer
            {
                Name = "A Son",
                Sdt = "+84 123456789"
            };

            var customer4 = new Customer
            {
                Name = "C Nhung",
                Sdt = "+84 123456789"
            };

            var customer5 = new Customer
            {
                Name = "C Thuy",
                Sdt = "+84 123456789"
            };
            _context.Customers.AddRange(new List<Customer>() { customer1, customer2, customer3, customer4, customer5 });
            await _context.SaveChangesAsync();
        }

        if (!_context.Categories.Any())
        {
            var category1 = new Category
            {
                Name = "Bút"
            };

            var category2 = new Category
            {
                Name = "Thước"
            };

            var category3 = new Category
            {
                Name = "Vở"
            };

            var category4 = new Category
            {
                Name = "Màu"
            };

            var category5 = new Category
            {
                Name = "Giấy"
            };
            _context.Categories.AddRange(new List<Category>() { category1, category2, category3, category4, category5 });
            await _context.SaveChangesAsync();
        }
    }

}
