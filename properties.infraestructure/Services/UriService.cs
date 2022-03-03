using System;
using System.Collections.Generic;
using System.Text;
using properties.core.QueryFilters;

namespace properties.infraestructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _UrlBase;
        public UriService(string UrlBase)
        {
            _UrlBase = UrlBase;
        }

        public Uri getPropertyPaginationUri(PropertyQueryFilters filters, string ActionUrl)
        {
            string UrlBase = $"{_UrlBase}{ActionUrl}";
            return new Uri(UrlBase);
        }


    }
}
