using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSample
{
    public class InterpretadorCsv : IInterpretador
    {
        private string[] _linhasCsv;
        private const char Separador = ';';

        public InterpretadorCsv()
        {
        }

        #region Membros de IInterpretador
        public void CarregarLinhas(string[] linhas)
        {
            _linhasCsv = linhas;
        }

        public IEnumerable<ExpandoObject> ObterObjetos()
        {
            return CriarListaObjetos(ObterNomesPropriedades(), ObterDados());
        }
        #endregion

        public string[] ObterNomesPropriedades()
        {
            var linhaCabecalho = _linhasCsv.First();
            return InterpretarItensLinha(linhaCabecalho);
        }

        public IEnumerable<string[]> ObterDados()
        {
            var linhasDados = _linhasCsv.Skip(1);
            return linhasDados.Select((linha) => InterpretarItensLinha(linha));
        }

        public string[] InterpretarItensLinha(string linha)
        {
            return linha.Split(Separador);
        }

        public IEnumerable<ExpandoObject> CriarListaObjetos(string[] nomesPropriedades, IEnumerable<string[]> dados)
        {
            foreach (var valoresPropriedades in dados)
            {
                yield return CriarObjetoComValores(nomesPropriedades, valoresPropriedades);
            }
        }

        public ExpandoObject CriarObjetoComValores(string[] listaPropriedades, string[] listaValores)
        {
            var objeto = new ExpandoObject() as IDictionary<string, object>;

            for (int i = 0; i < listaPropriedades.Length; i++)
            {
                var propriedade = listaPropriedades[i];
                var valor = listaValores[i];

                objeto.Add(propriedade, valor);
            }

            return objeto as ExpandoObject;
        }
    }
}
