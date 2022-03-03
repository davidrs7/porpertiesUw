using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace properties.api.Data
{
    public partial class propertiesContext : DbContext
    {
        public propertiesContext()
        {
        }

        public propertiesContext(DbContextOptions<propertiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyImage> PropertyImage { get; set; }
        public virtual DbSet<PropertyOwner> PropertyOwner { get; set; }
        public virtual DbSet<PropertyTrace> PropertyTrace { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty)
                    .HasName("PK__Property__842B6AA7C227F3E1");

                entity.Property(e => e.IdProperty).ValueGeneratedNever();

                entity.Property(e => e.AddressProperty)
                    .HasColumnName("Address_Property")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodeInternalProperty)
                    .HasColumnName("CodeInternal_Property")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameProperty)
                    .HasColumnName("Name_Property")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceProperty)
                    .HasColumnName("Price_property")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(e => e.IdPropertyImage)
                    .HasName("PK__property__018BACD59FA038B8");

                entity.ToTable("property_Image");

                entity.Property(e => e.IdPropertyImage).ValueGeneratedNever();

                entity.Property(e => e.EnabledP).HasColumnName("enabled_p");

                entity.Property(e => e.FileProperty)
                    .HasColumnName("file_property")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyOwner>(entity =>
            {
                entity.HasKey(e => e.IdOwner)
                    .HasName("PK__property__D32618166565A361");

                entity.ToTable("property_owner");

                entity.Property(e => e.IdOwner).ValueGeneratedNever();

                entity.Property(e => e.AddressOwner)
                    .HasColumnName("Address_Owner")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthdayOwner)
                    .HasColumnName("Birthday_Owner")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameOwner)
                    .HasColumnName("Name_Owner")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoOwner)
                    .HasColumnName("Photo_Owner")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyTrace>(entity =>
            {
                entity.HasKey(e => e.IdProperyTrace)
                    .HasName("PK__Property__CAEB89284C3FAD67");

                entity.Property(e => e.IdProperyTrace).ValueGeneratedNever();

                entity.Property(e => e.DateSalePtrace)
                    .HasColumnName("DateSale_Ptrace")
                    .HasColumnType("date");

                entity.Property(e => e.NamePtrace)
                    .HasColumnName("Name_Ptrace")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValuePtrace)
                    .HasColumnName("value_Ptrace")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
