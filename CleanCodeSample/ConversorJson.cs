using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSample
{
    public class ConversorJson : IConversor
    {
        #region Membros de IConversor
        public string Converter(IEnumerable<ExpandoObject> objetos)
        {
            return JsonConvert.SerializeObject(objetos, Formatting.Indented);
        }
        #endregion
    }
}
