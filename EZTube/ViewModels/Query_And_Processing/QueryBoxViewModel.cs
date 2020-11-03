using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Caliburn.Micro;
using EZTube.Models;

namespace EZTube.ViewModels.Query_And_Processing
{
    public class QueryBoxViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsIndeterminate { get; set; } = true;

        public QueryBoxViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Settings()
        {
            //Send Message To ShellViewModel For Showing Settings Page
            _eventAggregator.PublishOnUIThread(PageOptions.OpenSettings);
        }

        public void StartDownload()
        {
            //Send Message To ShellViewModel For Showing Settings Page
            _eventAggregator.PublishOnUIThread(PageOptions.OpenSingleDownloadPage);
        }
    }
}
