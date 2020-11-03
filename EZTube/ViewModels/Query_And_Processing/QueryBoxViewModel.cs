using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            //Send Message to ShellViewModel to Open Settings Page
            _eventAggregator.PublishOnUIThread(PageOptions.OpenSettings);
        }

        public void StartDownload(string urlBox)//Caliburn.Micro Will Automatically get string From TextBox
        {
            //Split Url List to Multiple Urls Without Repeating
            var urlList = urlBox.Split(Environment.NewLine).Distinct().ToArray();

            if (urlList.Length == 1)
            {
                //Send Message to ShellViewModel to Open SingleDownloadPage
                _eventAggregator.PublishOnUIThread(PageOptions.OpenSingleDownloadPage);
            }
            else if (urlList.Length > 1)
            {
                //Send Message to ShellViewModel to Open MultipleDownloadPage
                _eventAggregator.PublishOnUIThread(PageOptions.OpenMultipleDownloadPage);
            }
        }
    }
}
