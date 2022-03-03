using System;
using System.Collections.Generic;
using System.Text;
using properties.core.interfaces;
using properties.core.entities;
using System.Threading.Tasks;
using properties.core.exceptions;
using properties.core.QueryFilters;
using System.Linq;
using properties.core.DTO;
using properties.core.entities;
using Microsoft.Extensions.Options;

namespace properties.core.services
{    public class PropertyService : IPropertyService
    {
        public readonly IUnitOfWork _unitOfWork; 
        public readonly PaginationOptions _PaginationOptions;
        public PropertyService(IUnitOfWork unitOfWork,IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _PaginationOptions = options.Value;
        }
        public async Task<bool> deletePorperty(int id)
        {
            await _unitOfWork.PropertyRepository.Delete(id);
            return true;
        }
        public PageList<Property> getProperties(PropertyQueryFilters filters)
        {
            filters.pageNumber = filters.pageNumber == 0 ? _PaginationOptions.defaultPageNumber : filters.pageNumber;
            filters.pageSize = filters.pageSize  == 0 ? _PaginationOptions.defaultPageSize : filters.pageSize;

            var properties = _unitOfWork.PropertyRepository.GetAll();
            if (filters.idOwner != null) {
                properties = properties.Where(p => p.IdOwner == filters.idOwner);
            }
        
            if (filters.NameProperty != null)
            {
                properties = properties.Where(p => p.NameProperty.ToLower().Contains(filters.NameProperty));
            }

            var PropertiesPages = PageList<Property>.Create(properties, filters.pageNumber, filters.pageSize);

            return PropertiesPages;
        } 
        public async Task<Property> getProperty(int id)
        {
            return await _unitOfWork.PropertyRepository.GetById(id);
        }
        public async Task postProperty(Property Property)
        {
            var owner = await _unitOfWork.PropertyOwnerRepository.GetById(Property.IdOwner);

            if (owner == null)
            {
                throw new ExceptionsBusiness("Owner not exists");
            }

            if (Property.NameProperty.Contains("negro"))
            {
                throw new ExceptionsBusiness("Not exists black houses");
            }

            await _unitOfWork.PropertyRepository.Add(Property);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> PutPorperty(Property Property)
        {
              _unitOfWork.PropertyRepository.Update(Property);
               await  _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
