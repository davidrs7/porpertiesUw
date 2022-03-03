using System;
using System.Collections.Generic;
using System.Text;

namespace properties.core.QueryFilters
{
    public class PropertyQueryFilters
    {
        public int? idOwner { get; set; }
        public DateTime? date { get; set; }
        public string NameProperty { get; set; }

        public int pageSize { get; set; }
        public int pageNumber { get; set; }

    }
}
