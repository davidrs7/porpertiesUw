using System;
using System.Collections.Generic;

namespace properties.api.Data
{
    public partial class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int? IdProperty { get; set; }
        public string FileProperty { get; set; }
        public int? EnabledP { get; set; }
    }
}
