using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.Framework;
using EZTube.Models;
using EZTube.Services;
using EZTube.ViewModels.Pages;
using EZTube.ViewModels.Query_And_Processing;
using EZTube.Views.Pages;
using MaterialDesignThemes.Wpf;

namespace EZTube.ViewModels
{
    public class ShellViewModel
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

            //Create ViewModels for Components
            QueryBox = _viewModelFactory.CreateQueryBoxViewModel(new QueryService());
            QueryList = _viewModelFactory.CreateQueryListViewModel();
        }
    }
}
