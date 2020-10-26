using System;
using System.Collections.Generic;
using System.Text;
using EZTube.ViewModels.Pages;

namespace EZTube.Framework
{
    public static class Extensions
    {
        public static SettingsViewModel CreateSettingsViewModel(this IViewModelFactory factory)
        {
            return new SettingsViewModel();
        }
    }
}
