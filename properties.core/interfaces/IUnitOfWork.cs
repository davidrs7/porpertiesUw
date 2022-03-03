using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using properties.core.entities;

namespace properties.core.interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPropertyRepository PropertyRepository { get; }
        IRepository<PropertyOwner> PropertyOwnerRepository { get; }
        IRepository<PropertyImage> PropertyImageRepository { get; }
        IRepository<PropertyTrace> PropertyTraceRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
