using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using properties.core.entities;
using properties.infraestructure.data.configurations;

namespace properties.infraestructure.Data
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new property_ImageConfig());
            modelBuilder.ApplyConfiguration(new property_OwnerConfig());
            modelBuilder.ApplyConfiguration(new property_TraceConfig());

        }
         
    }
}
