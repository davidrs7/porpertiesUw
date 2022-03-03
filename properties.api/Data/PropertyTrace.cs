using System;
using System.Collections.Generic;

namespace properties.api.Data
{
    public partial class PropertyTrace
    {
        public int IdProperyTrace { get; set; }
        public int? IdProperty { get; set; }
        public DateTime? DateSalePtrace { get; set; }
        public string NamePtrace { get; set; }
        public string ValuePtrace { get; set; }
        public string Tax { get; set; }
    }
}
