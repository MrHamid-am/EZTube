using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.Models;

namespace EZTube.ViewModels.Query_And_Processing
{
    public class QueryListViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public BindableCollection<YouTubeVideo> DownloadsList { get; set; }

        public QueryListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            InitializeTestList();
        }

        private void InitializeTestList()
        {
            DownloadsList = new BindableCollection<YouTubeVideo>()
            {
                new YouTubeVideo("3 Scary Game","Mark","3 scary games number 1 bla bla bla...","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"){ProgressState = 50},
                new YouTubeVideo("3 Scary Game","Mark","3 scary games number 1 bla bla bla...","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"){ProgressState = 25},
                new YouTubeVideo("3 Scary Game","Mark","3 scary games number 1 bla bla bla...","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"){ProgressState = 30},
                new YouTubeVideo("3 Scary Game","Mark","3 scary games number 1 bla bla bla...","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"){ProgressState = 60},
                new YouTubeVideo("3 Scary Game","Mark","3 scary games number 1 bla bla bla...","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"){ProgressState = 80},
                new YouTubeVideo("3 Scary Game","Mark","3 scary games number 1 bla bla bla...","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"){ProgressState = 100},
            };
        }
    }
}
