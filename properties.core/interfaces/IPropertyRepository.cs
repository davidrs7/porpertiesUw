using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using properties.core.entities; 

namespace properties.core.interfaces
{
    public interface IPropertyRepository: IRepository<Property>
    {
        Task<IEnumerable<Property>> GetPropertyBuOwner(int id);

    }
}
