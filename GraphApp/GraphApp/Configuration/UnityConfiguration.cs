using System;
using System.Configuration;
using System.Globalization;
using GraphApp.BusinessLogic;
using GraphApp.LogicContracts;
using GraphApp.Presenters.Implementations;
using GraphApp.Presenters.Interfaces;
using GraphApp.Views.Implementations;
using GraphApp.Views.Interfaces;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace GraphApp.Configuration
{
    public static class UnityConfiguration
    {
        private static readonly string CultulreInfoString = ConfigurationManager.AppSettings["Language"];

        public static void RegisterServices(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMathGraph, MathGraph>();
            unityContainer.RegisterType<IMainPresenter, MainPresenter>();
            unityContainer.RegisterType<IMainView, MainForm>();
        }
    }
}