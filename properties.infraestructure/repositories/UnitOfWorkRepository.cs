using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using properties.core.entities;
using properties.core.interfaces;
using properties.infraestructure.Data;

namespace properties.infraestructure.repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly propertiesContext _dbconection;
        public readonly IPropertyRepository _propertyRepository;
        public readonly IRepository<PropertyOwner> _ownerRepository;
        public readonly IRepository<PropertyImage> _PropertyImageRepository;
        public readonly IRepository<PropertyTrace> _PropertyTraceRepository;

        public UnitOfWorkRepository(propertiesContext propertiesContext ) {
            _dbconection = propertiesContext;
        }
        public IPropertyRepository PropertyRepository => _propertyRepository ?? new PropertyRepository(_dbconection);

        public IRepository<PropertyOwner> PropertyOwnerRepository => _ownerRepository ?? new BaseRepository<PropertyOwner>(_dbconection);

        public IRepository<PropertyImage> PropertyImageRepository => _PropertyImageRepository ?? new BaseRepository<PropertyImage>(_dbconection);

        public IRepository<PropertyTrace> PropertyTraceRepository => _PropertyTraceRepository ?? new BaseRepository<PropertyTrace>(_dbconection);

        public void Dispose()
        {
            if (_dbconection != null) {
                _dbconection.Dispose();
            }
        }

        public void SaveChanges()
        {
            _dbconection.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _dbconection.SaveChangesAsync();
        }
    }
}
