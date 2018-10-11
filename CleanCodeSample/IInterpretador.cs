using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSample
{
    public interface IInterpretador
    {
        void CarregarLinhas(string[] linhas);

        IEnumerable<ExpandoObject> ObterObjetos();
    }
}
