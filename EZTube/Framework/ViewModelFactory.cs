using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.ViewModels.Query_And_Processing;

namespace EZTube.Framework
{
    public class ViewModelFactory
    {
        private readonly IEventAggregator _eventAggregator;

        public ViewModelFactory(IEventAggregator _eventAggregator)
        {
            this._eventAggregator = _eventAggregator;
        }

        public QueryBoxViewModel CreateQueryBoxViewModel()
        {
            var instance = new QueryBoxViewModel(_eventAggregator);

            return instance;
        }

        public QueryListViewModel CreateQueryListViewModel()
        {
            var instance = new QueryListViewModel(_eventAggregator);

            return instance;
        }
    }
}
