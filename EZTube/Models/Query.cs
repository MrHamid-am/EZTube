using System;
using System.Collections.Generic;
using System.Text;

namespace EZTube.Models
{
    public class Query
    {
        public QueryKind QueryKind { get; set; }
        public string Value { get; set; }

        public Query(QueryKind queryKind, string value)
        {
            QueryKind = queryKind;
            Value = value;
        }
    }

    public enum QueryKind
    {
        Video,
        Playlist,
        Channel,
        User,
        Search
    }
}
