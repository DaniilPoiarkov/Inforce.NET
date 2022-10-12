using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.Common.AuxiliaryModels.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity) : base($"Entity {entity} not found") { }
    }
}
