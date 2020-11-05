using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using EZTube.Framework;
using EZTube.Models;
using EZTube.Services;
using MaterialDesignThemes.Wpf;

namespace EZTube.ViewModels.Query_And_Processing
{
    public class QueryBoxViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly QueryService _queryService;
        private readonly IViewModelBinderFactory _binderFactory;

        public bool IsIndeterminate { get; set; } = true;

        public QueryBoxViewModel(IEventAggregator eventAggregator,
            QueryService queryService,
            IViewModelBinderFactory binderFactory)
        {
            _eventAggregator = eventAggregator;
            _queryService = queryService;
            _binderFactory = binderFactory;
        }

        public void Settings()
        {
            //Send Message to ShellViewModel to Open Settings Page
            _eventAggregator.PublishOnUIThread(PageOptions.OpenSettings);
        }

        public async void StartDownload(string urlBox)//Caliburn.Micro Will Automatically get string From TextBox
        {
            #region Temporary Codes

            //Split Url List to Multiple Urls Without Repeating
            //var urlList = urlBox.Split(Environment.NewLine).Distinct().ToArray();

            //if (urlList.Length == 1)
            //{
                //Send Message to ShellViewModel to Open SingleDownloadPage
            //    _eventAggregator.PublishOnUIThread(PageOptions.OpenSingleDownloadPage);
            //}
            //else if (urlList.Length > 1)
            //{
                //Send Message to ShellViewModel to Open MultipleDownloadPage
                //_eventAggregator.PublishOnUIThread(PageOptions.OpenMultipleDownloadPage);
            //}

            #endregion

            //Parse URLs into Separated Queries
            var parsedQueries = _queryService.ParseMultilineQuery(urlBox);
            
            //Execute Separated Queries
            var executedQueries = await _queryService.ExecuteMultiQueriesAsync(parsedQueries);

            //Get Videos from Executed Queries
            var videos = executedQueries.SelectMany(v => v.Videos).Distinct().ToArray();

            //if There is Only One Video
            if (videos.Length == 1)
            {
                var video = videos[0];

                var view = _binderFactory.CreateAndBindSingleDownloadViewModel();
                await DialogHost.Show(view);
            }
        }
    }
}
