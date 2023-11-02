using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetAPI.Data.Entities;

public class Product
{
    public int Id { set; get; }
    public int CategoryId { set; get; }
    public Category? Category { set; get; }
    public string? Name { set; get; }
    public string? Description { set; get; }
    public decimal Price { set; get; }
    public bool Status { set; get; } = true;
    public ICollection<OrderDetail>? OrderDetails { get; set; }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.Price)
            .HasPrecision(18, 0);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}