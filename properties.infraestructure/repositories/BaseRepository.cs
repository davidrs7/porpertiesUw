using System;
using System.Collections.Generic;
using System.Text;
using properties.core.interfaces;
using properties.core.entities;
using System.Threading.Tasks;
using properties.infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace properties.infraestructure.repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    { 
        private readonly propertiesContext _dbcontext;
        protected readonly DbSet<T> _entities;
        public BaseRepository(propertiesContext propertiesContext) {
            _dbcontext = propertiesContext;
            _entities = propertiesContext.Set<T>();
        }
        public   IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();             
        }

        public async Task<T> GetById(int? id)
        {
            return await _entities.FindAsync(id);
        }
        public async  Task Add(T entity)
        {
          await  _entities.AddAsync(entity);
          
        }
        public   void Update(T entity)
        {
            _entities.Update(entity); 
        }
        public async Task Delete(int id)
        {
            T entityRemove = await GetById(id);
            _entities.Remove(entityRemove); 
        } 
    }
}
