using System;
using System.Collections.Generic;

namespace properties.core.entities
{
    public partial class PropertyTrace: BaseEntity
    {
 
        public int? IdProperty { get; set; }
        public DateTime? DateSalePtrace { get; set; }
        public string NamePtrace { get; set; }
        public string ValuePtrace { get; set; }
        public string Tax { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
