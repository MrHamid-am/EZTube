using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Caliburn.Micro;

namespace EZTube.ViewModels.Pages
{
    public class SettingsViewModel:Screen
    {
        //Fody Property Changed Package Will Notify Changes Automatically
        public int MaxDownloads { get; set; }
        public string FileNameTemplate { get; set; }
    }
}
