using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetAPI.Data;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Sdt { get; set; }
    public ICollection<Order>? Orders { get; set; }
}

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Sdt)
            .IsRequired()
            .HasMaxLength(14);
    }
}