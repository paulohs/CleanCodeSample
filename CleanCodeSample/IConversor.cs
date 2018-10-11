using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSample
{
    public interface IConversor
    {
        string Converter(IEnumerable<ExpandoObject> objetos);
    }
}
