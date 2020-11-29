using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

namespace EZTube.Models
{
    public class VideoDownloadOption
    {
        /// <summary>
        /// Video Format Such as mp4,mkv,etc..
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Video Quality Label Such as 1080p,720p,etc..
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Video Stream infos
        /// </summary>
        public IReadOnlyList<IStreamInfo> StreamInfos { get; }

        /// <summary>
        /// Video Quality (Not labeled)
        /// </summary>
        public VideoQuality? VideoQuality =>
            StreamInfos.OfType<IVideoStreamInfo>()
                .Select(s => s.VideoQuality)
                .OrderByDescending(q => q)
                .FirstOrDefault();

        /// <summary>
        /// Video FPS
        /// </summary>
        public Framerate? Framerate =>
            StreamInfos.OfType<IVideoStreamInfo>()
                .Select(s => s.Framerate)
                .OrderByDescending(f => f)
                .FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format">Video Format</param>
        /// <param name="label">Video Quality label</param>
        /// <param name="streamInfos">Video Stream Infos</param>
        public VideoDownloadOption(string format, string label, IReadOnlyList<IStreamInfo> streamInfos)
        {
            Format = format;
            Label = label;
            StreamInfos = streamInfos;
        }

        //This Ctor Will Take Stream Info as Params 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format">Video Format</param>
        /// <param name="label">Video Quality label</param>
        /// <param name="streamInfos">Video Stream Infos</param>
        public VideoDownloadOption(string format, string label,params IStreamInfo[] streamInfos)
        {
            Format = format;
            Label = label;
            StreamInfos = streamInfos;
        }

        //an Override of ToString Method to return Quality Label and Video format in string
        public override string ToString() => $"{Label} / {Format}";
    }
}
