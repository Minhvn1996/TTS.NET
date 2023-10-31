using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetAPI.Data.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int ProductId { set; get; }
    public Product? Product { set; get; }
    public int OrderId { set; get; }
    public Order? Order { set; get; }
    public int Number { set; get; }
    public decimal Price { set; get; }
}

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Price)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.OrderId);
    }
}