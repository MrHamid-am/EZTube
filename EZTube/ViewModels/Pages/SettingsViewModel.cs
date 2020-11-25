﻿using System;
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
        private readonly SettingsManager<DownloaderSettings> _settingsManager;

        public SettingsViewModel(SettingsManager<DownloaderSettings> settingsManager)
        {
            _settingsManager = settingsManager;
        }

        protected override void OnViewLoaded(object view)
        {
            //Load Settings When View is Ready
            _settingsManager.LoadSettings();
            base.OnViewLoaded(view);
        }
    }
}
