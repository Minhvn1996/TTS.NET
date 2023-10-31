using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetAPI.Data;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { set; get; }
    public Customer? Customer { set; get; }
    public decimal TatolMoney { set; get; }
    public DateTime DateTimeCreated { set; get; }
    public ICollection<OrderDetail>? OrderDetails { get; set; }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.TatolMoney)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId);
    }
}