using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using properties.core.entities;
 

namespace properties.infraestructure.data.configurations
{
    public class property_ImageConfig : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.HasKey(e => e.id)
                     .HasName("PK__property__018BACD5B7261B59");

            builder.ToTable("property_Image");

            builder.Property(e => e.id).ValueGeneratedNever()
                   .HasColumnName("IdPropertyImage");

            builder.Property(e => e.EnabledP).HasColumnName("enabled_p");

            builder.Property(e => e.FileProperty)
                .HasColumnName("file_property")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPropertyNavigation)
                .WithMany(p => p.PropertyImage)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("FK__property___IdPro__68487DD7");
        }
    }
}
