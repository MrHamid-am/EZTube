using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using EZSettings;
using EZTube.Framework;
using EZTube.Models;
using EZTube.ViewModels;
using Unity;
using Unity.Lifetime;

namespace EZTube
{
    public class Bootstrapper : BootstrapperBase
    {
        private IUnityContainer _container = new UnityContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            //Register Containers
            _container.RegisterSingleton<IWindowManager, WindowManager>();
            _container.RegisterSingleton<IEventAggregator, EventAggregator>();

            //Register Factories
            _container.RegisterFactory<IViewModelFactory>(f => new ViewModelFactory(_container.Resolve<IEventAggregator>()));
            _container.RegisterFactory<IViewFactory>(f => new ViewFactory());
            _container.RegisterFactory<IViewModelBinderFactory>(f => new ViewModelBinderFactory(_container.Resolve<IViewModelFactory>(),
                                                                                                            _container.Resolve<IViewFactory>()));

            //Create Settings Manager
            var settingsManager = new SettingsManager<DownloaderSettings>(settingsConfiguration: new SettingsConfiguration()
            {
                FileName = "settings",
                GiveErrorIfCannotLoad = true,
                GiveErrorIfCannotSave = true,
                IsAutoSave = true
            });
            _container.RegisterInstance(settingsManager,new SingletonLifetimeManager());
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.ResolveAll(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.Resolve(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
