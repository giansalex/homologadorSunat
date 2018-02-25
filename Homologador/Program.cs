using Autofac;
using Homologador.Config;
using System;
using System.Windows.Forms;

namespace Homologador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = AutoFacConfig.BootStrap();

            Application.Run(container.Resolve<MainForm>());
        }
    }
}
