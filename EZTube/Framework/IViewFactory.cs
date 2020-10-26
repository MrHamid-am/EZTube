using System;
using System.Collections.Generic;
using System.Text;
using EZTube.Views.Pages;

namespace EZTube.Framework
{
    public interface IViewFactory
    {
        SettingsView CeateSettingsView();
    }
}
