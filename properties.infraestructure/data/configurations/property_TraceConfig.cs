using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using properties.core.entities;

namespace properties.infraestructure.data.configurations
{
    public class property_TraceConfig : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.HasKey(e => e.id)
                  .HasName("PK__Property__CAEB89282A521F0F");

            builder.Property(e => e.id).ValueGeneratedNever()
                   .HasColumnName("IdProperyTrace");

            builder.Property(e => e.DateSalePtrace)
                .HasColumnName("DateSale_Ptrace")
                .HasColumnType("date");

            builder.Property(e => e.NamePtrace)
                .HasColumnName("Name_Ptrace")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Tax)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ValuePtrace)
                .HasColumnName("value_Ptrace")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPropertyNavigation)
                .WithMany(p => p.PropertyTrace)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("FK__PropertyT__IdPro__6B24EA82");
        }
    }
}
