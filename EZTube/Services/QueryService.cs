using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZTube.Models;
using YoutubeExplode.Converter;
using YoutubeExplode;
using YoutubeExplode.Channels;
using YoutubeExplode.Playlists;
using YoutubeExplode.Videos;

namespace EZTube.Services
{
    public partial class QueryService
    {
        private readonly YoutubeClient _youtubeClient = new YoutubeClient();

        //This Method Will Detect The Input Url Data Type
        public Query ParseQuery(string query)
        {
            //Remove All Spaces
            query = query.Trim();

            //if Url is Playlist
            var playlistId = TryParsePlaylistId(query);
            if (playlistId != null)
            {
                return new Query(QueryKind.Playlist, playlistId.Value);
            }

            //if Url is Video
            var videoId = TryParseVideoId(query);
            if (videoId != null)
            {
                return new Query(QueryKind.Video, videoId.Value);
            }

            //if Url is Channel
            var channelId = TryParseChannelId(query);
            if (channelId != null)
            {
                return new Query(QueryKind.Channel, channelId.Value);
            }

            //if Url is User
            var userName = TryParseUserName(query);
            if (userName != null)
            {
                return new Query(QueryKind.User, userName.Value);
            }

            //if it's Not a Url
            {
                return new Query(QueryKind.Search, query);
            }
        }

        //Parse Multi URLs Input to Query
        public IReadOnlyList<Query> ParseMultilineQuery(string query)
        {
            return query.Split(Environment.NewLine).Select(ParseQuery).ToArray();
        }
    }

    public partial class QueryService
    {
        private static VideoId? TryParseVideoId(string query)
        {
            try
            {
                return new VideoId(query);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static PlaylistId? TryParsePlaylistId(string query)
        {
            try
            {
                return new PlaylistId(query);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static ChannelId? TryParseChannelId(string query)
        {
            try
            {
                return new ChannelId(query);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static UserName? TryParseUserName(string query)
        {
            try
            {
                // Only URLs
                if (!query.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                    !query.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    return null;

                return new UserName(query);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
