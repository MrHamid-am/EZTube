using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.ViewModels.Pages;
using EZTube.Views.Pages;

namespace EZTube.Framework
{
    public static class Extensions
    {
        public static SettingsViewModel CreateSettingsViewModel(this IViewModelFactory factory)
        {
            return new SettingsViewModel();
        }

        public static SingleDownloadViewModel CreateSingleDownloadViewModel(this IViewModelFactory factory)
        {
            return new SingleDownloadViewModel();
        }

        public static SingleDownloadView CreateSingleDownloadView(this IViewFactory factory)
        {
            return new SingleDownloadView();
        }

        public static SingleDownloadView CreateAndBindSingleDownloadViewModel(this IViewModelBinderFactory binderFactory,object creationContext = null)
        {
            //Create View And ViewModel With Factories
            var viewModel = IoC.Get<IViewModelFactory>().CreateSingleDownloadViewModel();
            var view = IoC.Get<IViewFactory>().CreateSingleDownloadView();

            //Bind ViewModel To It's View
            Caliburn.Micro.ViewModelBinder.Bind(viewModel, view, creationContext);

            return view;
        }
    }
}
