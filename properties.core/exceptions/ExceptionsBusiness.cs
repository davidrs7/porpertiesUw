using System;
using System.Collections.Generic;
using System.Text;

namespace properties.core.exceptions
{
    public class ExceptionsBusiness: Exception
    {
        public ExceptionsBusiness()
        {

        } 
        public ExceptionsBusiness(string message): base(message)
        {

        }
    }
}
