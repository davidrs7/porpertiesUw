using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using properties.core.entities;

namespace properties.infraestructure.data.configurations
{
    public class property_OwnerConfig : IEntityTypeConfiguration<PropertyOwner>
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            builder.HasKey(e => e.id)
                  .HasName("PK__property__D3261816010AF402");

            builder.ToTable("property_owner");

            builder.Property(e => e.id).ValueGeneratedNever()
                   .HasColumnName("IdOwner");

            builder.Property(e => e.AddressOwner)
                .HasColumnName("Address_Owner")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.BirthdayOwner)
                .HasColumnName("Birthday_Owner")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NameOwner)
                .HasColumnName("Name_Owner")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PhotoOwner)
                .HasColumnName("Photo_Owner")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
