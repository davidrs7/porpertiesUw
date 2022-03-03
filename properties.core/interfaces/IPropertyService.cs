using properties.core.entities;
using properties.core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;
using properties.core.DTO;

namespace properties.core.interfaces
{
    public interface IPropertyService
    {
        PageList<Property> getProperties(PropertyQueryFilters fitlers);
        Task<Property> getProperty(int id);
        Task postProperty(Property Property);
        Task<bool> deletePorperty(int id);
        Task<bool> PutPorperty(Property Property);
    }
}