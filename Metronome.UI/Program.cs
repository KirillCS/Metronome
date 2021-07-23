using Metronome.UI.Forms;
using System;
using System.Windows.Forms;
using Metronome.DependencyResolver;

namespace Metronome.UI
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServiceProvider = Resolver.CreateServiceProvider();
            Application.Run(new MetronomeForm());
        }
    }
}
