using System;
using System.Collections.Generic;
using System.Text;

namespace EZTube.Models
{
    /*
     * This is Query class
     * Which Will be Processed And Executed
     */
    public class Query
    {
        //Kind of The Query. Represent Which Query Type is Executing
        public QueryKind QueryKind { get; set; }

        //Value of The Query. its Depend on Query Kind. it Can Be ChannelId,UserId,etc.
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
