using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.Application.Exceptions
{
    public class NotFoundException(string property): Exception($"The {property} not found")
    {
    }
}
