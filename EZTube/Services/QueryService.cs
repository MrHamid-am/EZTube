using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //This Method Will Detect The Input Url Data Type And Builds Query
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

        // When an Query Determined  its Need to Execute
        public async Task<ExecutedQuery> ExecuteQueryAsync(Query query)
        {
            //if Query is Video Then Query Value Should be VideoId Which We Need Here
            if (query.QueryKind == QueryKind.Video)
            {
                var video = await _youtubeClient.Videos.GetAsync(query.Value);

                return new ExecutedQuery(query, new[] { video }, video.Title);
            }

            //if Query is Playlist Then Query Value Should Be PlaylistId Which We need Here
            if (query.QueryKind == QueryKind.Playlist)
            {
                var playlist = await _youtubeClient.Playlists.GetAsync(query.Value);
                var videos = await _youtubeClient.Playlists.GetVideosAsync(query.Value).BufferAsync();

                return new ExecutedQuery(query, videos, playlist.Title);
            }

            //.... Query Value Should Be ChannelId Which We need Here
            if (query.QueryKind == QueryKind.Channel)
            {
                var channel = await _youtubeClient.Channels.GetAsync(query.Value);
                var videos = await _youtubeClient.Channels.GetUploadsAsync(query.Value).BufferAsync();

                //This is a Channel And User Can Select Videos Form Channel to Download
                return new ExecutedQuery(query, videos, $"Channel Uploads: {channel.Title}");
            }

            //.... User
            if (query.QueryKind == QueryKind.User)
            {
                //Get User Channel
                var channel = await _youtubeClient.Channels.GetByUserAsync(query.Value);

                //Get Videos Associated With User Channel 
                var videos = await _youtubeClient.Channels.GetUploadsAsync(channel.Id).BufferAsync();

                return new ExecutedQuery(query, videos, channel.Title);
            }

            /*
             * if input is not a Url We Will Search Keywords And Get Videos That Contains Associated Keywords
             * We Only Get 200 Top Videos
             */
            if (query.QueryKind == QueryKind.Search)
            {
                var videos = await _youtubeClient.Search.GetVideosAsync(query.Value).BufferAsync(200);

                return new ExecutedQuery(query, videos, $"Search Result for {query.Value}");
            }

            //This is Last Situation Query is Not Valid
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("URLs Are Not Valid")
                .AppendLine("Please Enter Valid Url or Use Good Keywords To Search Videos");
            throw new Exception(sb.ToString());
        }

        //This Method Will Execute Multi Queries
        public async Task<IReadOnlyList<ExecutedQuery>> ExecuteMultiQueriesAsync(IReadOnlyList<Query> queries)
        {
            var result = new List<ExecutedQuery>();

            foreach (var query in queries)
            {
                //Execute Query
                var executedQuery = await ExecuteQueryAsync(query);
                result.Add(executedQuery);
            }

            return result;
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
