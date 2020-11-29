using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZSettings;
using EZTube.Models;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace EZTube.Services
{
    public class DownloadService
    {
        private readonly YoutubeClient _youtube = new YoutubeClient();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private readonly SettingsManager<DownloaderSettings> _settings;

        public DownloadService(SettingsManager<DownloaderSettings> settings)
        {
            _settings = settings;
        }

        //Get Ordered Available Video Options
        public async Task<IReadOnlyList<VideoDownloadOption>> GetVideoOptionAsync(string videoId)
        {
            //Get Information About Available Video Streams
            var streamManifest = await _youtube.Videos.Streams.GetManifestAsync(videoId);

            // Using a set ensures only one download option per format & quality is provided
            var options = new HashSet<VideoDownloadOption>();

            /*
             * Videos on Stream Manifest Contains Muxed Videos and Video-Only videos (like a gif)
             * as mentioned above this streams can Includes Videos That Doesn't have Audio
             * We Should try to combine Audio and Video of this streams if they are not muxed streams
             * Combine Will Happens During Download
             */
            var videoStreams = streamManifest
                .GetVideo()
                .OrderByDescending(v => v.VideoQuality)
                .ThenByDescending(v => v.Framerate);

            foreach (var streamInfo in videoStreams)
            {
                //Get video format
                var format = streamInfo.Container.Name;

                //Get Video Quality Label
                var label = streamInfo.VideoQualityLabel;

                //if this is Muxed stream Then we Done
                if (streamInfo is MuxedStreamInfo)
                {
                    options.Add(new VideoDownloadOption(format, label, streamInfo));
                    continue;
                }

                //Get Audio with Matching format if Possible
                var audioStreamInfo = (IStreamInfo)
                    streamManifest.GetAudioOnly()
                        .OrderByDescending(s => s.Container == streamInfo.Container)
                        .ThenByDescending(s => s.Bitrate == streamInfo.Bitrate)
                        .FirstOrDefault() ??
                    streamManifest.GetMuxed()
                        .OrderByDescending(s => s.Container == streamInfo.Container)
                        .ThenByDescending(s => s.Bitrate == streamInfo.Bitrate)
                        .FirstOrDefault();

                if (audioStreamInfo is not null)
                {
                    options.Add(new VideoDownloadOption(format, label, streamInfo, audioStreamInfo));
                }
            }

            //Get Video Best Audios
            var bestAudioOnlyStreamInfos = streamManifest.GetAudio()
                .OrderByDescending(s => s.Container == Container.WebM)
                .ThenByDescending(s => s.Bitrate)
                .FirstOrDefault();

            if (bestAudioOnlyStreamInfos is not null)
            {
                options.Add(new VideoDownloadOption("mp3", "Audio", bestAudioOnlyStreamInfos));
                options.Add(new VideoDownloadOption("ogg", "Audio", bestAudioOnlyStreamInfos));
            }

            // Drop excluded formats
            if (_settings.Model.ExcludedContainerFormats is not null)
            {
                options.RemoveWhere(o => _settings.Model.ExcludedContainerFormats.Contains(o.Format, StringComparer.OrdinalIgnoreCase));
            }

            return options.ToArray();
        }

        public async Task<IReadOnlyList<SubtitleDownloadOption>> GetSubtitleOptionsAsync(string videoId)
        {
            //Get Information About Available Subtitles for Video
            var closedCaptionManifest = await _youtube.Videos.ClosedCaptions.GetManifestAsync(videoId);

            return closedCaptionManifest.Tracks.Select(t => new SubtitleDownloadOption(t))
                .ToArray();
        }
    }
}
