using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.Framework;
using EZTube.ViewModels.Query_And_Processing;

namespace EZTube.ViewModels
{
    public class ShellViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IViewModelFactory _viewModelFactory;

        //Box Of Inputs Such as TextBox and button and...
        public QueryBoxViewModel QueryBox { get; }

        //List Of Downloading Videos
        public QueryListViewModel QueryList { get; }

        public ShellViewModel(IEventAggregator _eventAggregator,
            IViewModelFactory viewModelFactory)
        {
            this._eventAggregator = _eventAggregator;
            _viewModelFactory = viewModelFactory;

            QueryBox = viewModelFactory.CreateQueryBoxViewModel();
            QueryList = viewModelFactory.CreateQueryListViewModel();
        }
    }
}
