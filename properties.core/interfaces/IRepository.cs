using System;
using System.Collections.Generic;
using System.Text;
using properties.core.entities;
using System.Threading.Tasks;

namespace properties.core.interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int? id);
        Task Add(T Entity);
        void Update(T Entity);
        Task Delete(int id);
    }
}
