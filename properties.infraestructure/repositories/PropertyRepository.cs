using properties.core.entities;
using System;
using System.Collections.Generic;
using System.Text;
using properties.core.interfaces;
using System.Threading.Tasks;
using properties.infraestructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace properties.infraestructure.repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
      
        public PropertyRepository(propertiesContext dbConnection) : base(dbConnection)     { }
        public async Task<IEnumerable<Property>> GetPropertyBuOwner(int idOwner)
        {
            return await _entities.Where(p => p.IdOwner == idOwner).ToListAsync();
        }
    }
}
