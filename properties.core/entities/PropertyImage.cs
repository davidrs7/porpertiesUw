using System;
using System.Collections.Generic;

namespace properties.core.entities
{
    public partial class PropertyImage : BaseEntity
    {
 
        public int? IdProperty { get; set; }
        public string FileProperty { get; set; }
        public int? EnabledP { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
