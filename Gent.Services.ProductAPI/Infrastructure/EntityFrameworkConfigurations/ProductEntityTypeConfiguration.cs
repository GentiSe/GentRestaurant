using Gent.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gent.Services.ProductAPI.Infrastructure.EntityFrameworkConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.Property(d => d.Id)
               .ValueGeneratedOnAdd()
               .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Price).IsRequired();
            b.Property(x => x.Description).IsRequired();
            b.Property(x => x.CategoryName).IsRequired();
            b.Property(x => x.ImageUrl).IsRequired();


            b.HasKey(x => x.Id);

            b.ToTable("Products");
        }
    }
}
