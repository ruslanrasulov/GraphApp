using System;
using System.Windows.Forms;
using GraphApp.Configuration;
using GraphApp.Views.Interfaces;
using Unity;

namespace GraphApp
{
    internal static class Program
    {
        private static readonly IUnityContainer UnityContainer;

        static Program()
        {
            UnityContainer = new UnityContainer();
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UnityConfiguration.RegisterServices(UnityContainer);

            var mainForm = UnityContainer.Resolve<IMainView>();

            Application.Run(mainForm as Form);
        }
    }
}