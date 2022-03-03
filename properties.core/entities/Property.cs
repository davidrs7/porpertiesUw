using System.Collections.Generic;

namespace properties.core.entities
{
    public partial class Property : BaseEntity
    {
        public Property()
        {
            PropertyImage = new HashSet<PropertyImage>();
            PropertyTrace = new HashSet<PropertyTrace>();
        }

 
        public int? IdOwner { get; set; }
        public string NameProperty { get; set; }
        public string AddressProperty { get; set; }
        public decimal? PriceProperty { get; set; }
        public string CodeInternalProperty { get; set; }

        public virtual ICollection<PropertyImage> PropertyImage { get; set; }
        public virtual ICollection<PropertyTrace> PropertyTrace { get; set; }
    }
}
