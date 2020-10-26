using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.Framework;
using EZTube.Models;
using EZTube.ViewModels.Pages;
using EZTube.ViewModels.Query_And_Processing;
using EZTube.Views.Pages;
using MaterialDesignThemes.Wpf;

namespace EZTube.ViewModels
{
    public class ShellViewModel : IHandle<PageOptions>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelBinderFactory _viewModelBinderFactory;

        //Box Of Inputs Such as TextBox and button and...
        public QueryBoxViewModel QueryBox { get; }

        //List Of Downloading Videos
        public QueryListViewModel QueryList { get; }

        public ShellViewModel(IEventAggregator _eventAggregator,
            IViewModelFactory viewModelFactory,IViewModelBinderFactory viewModelBinderFactory)
        {
            this._eventAggregator = _eventAggregator;
            _viewModelFactory = viewModelFactory;
            _viewModelBinderFactory = viewModelBinderFactory;

            QueryBox = viewModelFactory.CreateQueryBoxViewModel();
            QueryList = viewModelFactory.CreateQueryListViewModel();

            //Subscribe To Pages Moving
            _eventAggregator.Subscribe(this);
        }

        public void Handle(PageOptions message)
        {
            switch (message)
            {
                //Show Settings Page
                case PageOptions.OpenSettings:
                {
                    //Get View From Settings ViewModel
                    var view = _viewModelBinderFactory.CreateAndBindSettingsViewModel();

                    //Show settings
                    DialogHost.Show(view);
                    break;
                }
                    
            }
        }
    }
}
