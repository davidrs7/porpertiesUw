using System;
using System.Collections.Generic;

namespace properties.core.entities
{
    public partial class PropertyOwner : BaseEntity
    {
 
        public string NameOwner { get; set; }
        public string AddressOwner { get; set; }
        public string PhotoOwner { get; set; }
        public string BirthdayOwner { get; set; }
    }
}
