using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSample
{
    public class ConversorArquivo
    {
        private readonly IInterpretador _interpretador;
        private readonly IConversor _conversor;

        private string[] _entrada;
        private string _resultado;

        public ConversorArquivo(IInterpretador interpretador, IConversor conversor)
        {
            _interpretador = interpretador;
            _conversor = conversor;
        }

        public void Converter()
        {
            _interpretador.CarregarLinhas(_entrada);
            _resultado = _conversor.Converter(_interpretador.ObterObjetos());
        }

        public void CarregarArquivo(string caminhoArquivoCsv)
        {
            _entrada = File.ReadAllLines(caminhoArquivoCsv, Encoding.UTF8);
        }

        public void SalvarArquivo(string caminhoArquivoJson)
        {
            File.WriteAllText(caminhoArquivoJson, _resultado, Encoding.UTF8);
        }

    }
}
