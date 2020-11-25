using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using YoutubeExplode.Videos.Streams;

namespace EZTube.Models
{
    public class DownloadSettings : INotifyPropertyChanged
    {
        public int MaxConCurrentDownloads { get; set; } = 2;

        public string FileNameTemplate { get; set; }

        public IReadOnlyList<string> ExcludedContainerFormats { get; set; }

        public bool IsAutoUpdate { get; set; } = true;

        public bool IsDarkMode { get; set; }

        public bool InjectMediaTags { get; set; } = true;

        public bool SkipExistingFiles { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
