using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainSujo(args);
            MainClean(args);
            MainCleanComDI(args);
        }

        public static void MainSujo(string[] args)
        {
            // Leitura do arquivo
            var e = File.ReadAllLines(args[0], Encoding.UTF8);
            if (e.Length > 0)
            {
                var objs = new List<ExpandoObject>();
                string[] c = null;
                for (int i = 0; i < e.Length; i++)
                {
                    var obj = new ExpandoObject() as IDictionary<string, object>;
                    if (i == 0)
                        // Usa primeira linha como propriedades do objeto
                        c = e[i].Split(';');
                    else
                    {
                        // Outras linhas são os valores
                        var v = e[i].Split(';');
                        for (int j = 0; j < v.Length; j++)
                        {
                            obj[c[j]] = v[j];
                        }
                        // Adiciona linha na lista de objetos
                        objs.Add(obj as ExpandoObject);
                    }
                }
                // Salva arquivo de saida
                File.WriteAllText(Path.GetFileNameWithoutExtension(args[0]) + ".json",
                    JsonConvert.SerializeObject(objs, Formatting.Indented), Encoding.UTF8);
            }
            else
                Console.WriteLine("Arquivo não possui linhas.");
        }

        public static void MainClean(string[] args)
        {
            var caminhoArquivoCsv = args[0];
            var caminhoArquivoJson = Path.GetFileNameWithoutExtension(caminhoArquivoCsv) + ".json";

            var interpretadorCsv = new InterpretadorCsv();
            var conversorJson = new ConversorJson();

            var conversor = new ConversorArquivo(interpretadorCsv, conversorJson);

            conversor.CarregarArquivo(caminhoArquivoCsv);
            conversor.Converter();
            conversor.SalvarArquivo(caminhoArquivoJson);
        }

        public static void MainCleanComDI(string[] args)
        {
            var caminhoArquivoCsv = args[0];
            var caminhoArquivoJson = Path.GetFileNameWithoutExtension(caminhoArquivoCsv) + ".json";

            var conversor = IoC.Kernel.Get<ConversorArquivo>();

            conversor.CarregarArquivo(caminhoArquivoCsv);
            conversor.Converter();
            conversor.SalvarArquivo(caminhoArquivoJson);
        }
    }    
}