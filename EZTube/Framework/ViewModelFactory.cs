﻿using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.Services;
using EZTube.ViewModels.Query_And_Processing;
using Unity;

namespace EZTube.Framework
{
    public class ViewModelFactory:IViewModelFactory
    {
        private readonly IEventAggregator _eventAggregator;

        public ViewModelFactory(IEventAggregator _eventAggregator)
        {
            this._eventAggregator = _eventAggregator;
        }

        public QueryBoxViewModel CreateQueryBoxViewModel(QueryService queryService)
        {
            var instance = new QueryBoxViewModel(
                _eventAggregator,
                queryService, 
                IoC.Get<IViewModelBinderFactory>(),
                IoC.Get<DownloadService>()
                );

            return instance;
        }

        public QueryListViewModel CreateQueryListViewModel()
        {
            var instance = new QueryListViewModel(_eventAggregator);

            return instance;
        }
    }
}
