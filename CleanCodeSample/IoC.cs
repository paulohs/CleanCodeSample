using Ninject;

namespace CleanCodeSample
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; }

        static IoC()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<IInterpretador>().To<InterpretadorCsv>();
            Kernel.Bind<IConversor>().To<ConversorJson>();
            Kernel.Bind<ConversorArquivo>().ToSelf();
        }
    }
}
