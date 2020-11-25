using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Caliburn.Micro;
using EZSettings;
using EZTube.Models;

namespace EZTube.ViewModels.Pages
{
    public class SettingsViewModel:Screen
    {
        public SettingsManager<DownloaderSettings> SettingsManager { get; }

        public SettingsViewModel(SettingsManager<DownloaderSettings> settingsManager)
        {
            SettingsManager = settingsManager;

            //Load Settings
            SettingsManager?.LoadSettings();
        }
    }
}
