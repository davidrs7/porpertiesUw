using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using properties.core.entities;
namespace properties.infraestructure.data.configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(e => e.id)
               
               .HasName("PK__Property__842B6AA7B1F47A4F");

            builder.Property(e => e.id).ValueGeneratedNever()
               .HasColumnName("IdProperty");

            builder.Property(e => e.AddressProperty)
                .HasColumnName("Address_Property")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CodeInternalProperty)
                .HasColumnName("CodeInternal_Property")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NameProperty)
                .HasColumnName("Name_Property")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PriceProperty)
                .HasColumnName("Price_property")
                .HasColumnType("money");
        }
    }
}
