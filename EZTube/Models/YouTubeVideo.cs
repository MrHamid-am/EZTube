using System;
using System.Collections.Generic;
using System.Text;

namespace EZTube.Models
{
    public class YouTubeVideo
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Details { get; set; }
        public double ProgressState { get; set; }
        public string VideoThumb { get; set; }
        public DateTime UploadDate { get; set; }
        public TimeSpan Duration { get; set; }

        public YouTubeVideo(string title, string author, string details, string videoThumb)
        {
            Title = title;
            Author = author;
            Details = details;
            VideoThumb = videoThumb;
        }
    }
}
