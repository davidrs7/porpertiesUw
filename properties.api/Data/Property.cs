using System;
using System.Collections.Generic;

namespace properties.api.Data
{
    public partial class Property
    {
        public int IdProperty { get; set; }
        public int? IdOwner { get; set; }
        public string NameProperty { get; set; }
        public string AddressProperty { get; set; }
        public decimal? PriceProperty { get; set; }
        public string CodeInternalProperty { get; set; }
    }
}
