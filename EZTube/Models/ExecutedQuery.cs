using System;
using System.Collections.Generic;
using System.Text;
using YoutubeExplode.Videos;

namespace EZTube.Models
{
    public class ExecutedQuery
    {
        public Query Query { get; set; }
        public IReadOnlyList<Video> Videos { get; set; }
        public string Title { get; set; }

        public ExecutedQuery(Query query, IReadOnlyList<Video> videos, string title)
        {
            Query = query;
            Videos = videos;
            Title = title;
        }
    }
}
