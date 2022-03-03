using properties.core.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace properties.core.interfaces
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<PropertyOwner>> getOwners();

        Task<PropertyOwner> getOwner(int? id);
    }
}
