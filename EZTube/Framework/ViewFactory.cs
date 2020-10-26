using System;
using System.Collections.Generic;
using System.Text;
using EZTube.Views.Pages;

namespace EZTube.Framework
{
    public class ViewFactory:IViewFactory
    {
        public SettingsView CeateSettingsView()
        {
            return new SettingsView();
        }
    }
}
