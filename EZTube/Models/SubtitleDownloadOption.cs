using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.ClosedCaptions;

namespace EZTube.Models
{
    public class SubtitleDownloadOption
    {
        public ClosedCaptionTrackInfo TrackInfo { get; }

        public SubtitleDownloadOption(ClosedCaptionTrackInfo trackInfo)
        {
            TrackInfo = trackInfo;
        }

        public override string ToString() => TrackInfo.Language.ToString();
    }
}
