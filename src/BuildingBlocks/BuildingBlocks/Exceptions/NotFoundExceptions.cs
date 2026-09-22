using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Exceptions
{
    public class NotFoundExceptions:Exception
    {
        public NotFoundExceptions(string message):base(message)
        {
            
        }
        public NotFoundExceptions(string Name,object Key):base($"Entity \"{Name}\"({Key}) was not found")
        {
            
        }
    }
}
