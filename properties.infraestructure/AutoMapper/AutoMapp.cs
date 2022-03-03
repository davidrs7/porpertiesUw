using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using properties.core.DTO;
using properties.core.entities;

namespace properties.infraestructure.AutoMapper
{
    public class AutoMapp:  Profile
    {
        public AutoMapp() {
            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyDto, Property>();
            CreateMap<PropertyOwner, PropertyOwnerDto>();
            CreateMap<PropertyOwnerDto, PropertyOwner>();

       }
    }
}
