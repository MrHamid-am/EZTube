using System;
using System.Collections.Generic;
using System.Text;
using YoutubeExplode.Videos;

namespace EZTube.Models
{
    /*
     * This is ExecutedQuery Class
     * As the name implies this Class is The Result of Query Execution
     */
    public class ExecutedQuery
    {
        //Processed Query
        public Query Query { get; set; }

        /*
         * a Readonly List of Videos And Their Details
         * Which is Result of Query Execution (Depends on QueryKind it Will Be Different such as Playlist Videos, Channel Videos,etc.)
         */
        public IReadOnlyList<Video> Videos { get; set; }

        /*
         * Title of Executed Query
         * Depends on QueryKind it Will Be Different such as Playlist Title, Channel Name,etc.
         */
        public string Title { get; set; }

        public ExecutedQuery(Query query, IReadOnlyList<Video> videos, string title)
        {
            Query = query;
            Videos = videos;
            Title = title;
        }
    }
}
