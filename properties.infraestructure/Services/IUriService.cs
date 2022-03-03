using properties.core.QueryFilters;
using System;

namespace properties.infraestructure.Services
{
    public interface IUriService
    {
        Uri getPropertyPaginationUri(PropertyQueryFilters filters, string ActionUrl);
    }
}