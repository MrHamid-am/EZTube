using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using YoutubeExplode.Videos.Streams;

namespace EZTube.Models
{
    public class DownloaderSettings : INotifyPropertyChanged
    {
        public int MaxConCurrentDownloads { get; set; } = 3;

        public string FileNameTemplate { get; set; }

        public IReadOnlyList<string> ExcludedContainerFormats { get; set; } = Array.Empty<string>();

        public bool IsAutoUpdate { get; set; } = true;

        public bool IsDarkMode { get; set; }

        public bool InjectMediaTags { get; set; } = true;

        public bool SkipExistingFiles { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
