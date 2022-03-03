using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using properties.core.DTO;

namespace properties.api.Response
{
    public class Responses<T>
    {

        public Responses(T data) {
            Data = data;
        }

        public T Data { get; set; }

        public MetaData MetaData { get; set; }

    }
}
