using System;
using System.Collections.Generic;
using System.Text;
using EZTube.ViewModels.Pages;
using EZTube.Views.Pages;

namespace EZTube.Framework
{
    //This Class Will Create View And ViewModel Both And Bind ViewModel To it's View
    public class ViewModelBinderFactory : IViewModelBinderFactory
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewFactory _viewFactory;

        public ViewModelBinderFactory(IViewModelFactory viewModelFactory, IViewFactory viewFactory)
        {
            //ViewModel Factory To Create ViewModel
            _viewModelFactory = viewModelFactory;
            
            //View Factory To Create View
            _viewFactory = viewFactory;
        }

        public SettingsView CreateAndBindSettingsViewModel(object creationContext = null)
        {
            //Create View And ViewModel With Factories
            var viewModel = _viewModelFactory.CreateSettingsViewModel();
            var view = _viewFactory.CreateSettingsView();

            //Bind ViewModel To It's View
            Caliburn.Micro.ViewModelBinder.Bind(viewModel, view, creationContext);

            return view;
        }
    }
}
