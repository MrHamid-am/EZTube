using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EZTube.Models;

namespace EZTube.ViewModels.Pages
{
    public class MultipleDownloadViewModel : Screen
    {
        public List<YouTubeVideo> RequestedDownloads { get; set; }

        public MultipleDownloadViewModel()
        {
            InitializeTestList();
        }

        private void InitializeTestList()
        {
            RequestedDownloads = new List<YouTubeVideo>()
            {
                new YouTubeVideo("3 Scary Game","Mark","","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"),
                new YouTubeVideo("3 Scary Game","Mark","","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"),
                new YouTubeVideo("3 Scary Game","Mark","","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"),
                new YouTubeVideo("3 Scary Game","Mark","","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"),
                new YouTubeVideo("3 Scary Game","Mark","","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"),
                new YouTubeVideo("3 Scary Game","Mark","","https://d12avs59aaiyvm.cloudfront.net/wp-content/uploads/2018/02/Markiplier-youtube.jpg"),
            };
        }
    }
}
