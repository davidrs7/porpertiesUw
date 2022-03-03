using System;
using System.Collections.Generic;
using System.Text;

namespace properties.core.DTO
{
   public class PropertyDto
    {
        /// <summary>
        /// Id table Property 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Owner references table Owners
        /// </summary>
        public int? IdOwner { get; set; }
        /// <summary>
        /// Name property 
        /// </summary>
        public string NameProperty { get; set; }
        public string AddressProperty { get; set; }
        public decimal? PriceProperty { get; set; }
        public string CodeInternalProperty { get; set; }
    }
}
