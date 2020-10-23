using System;
using System.Collections.Generic;
using System.Text;
using EZTube.ViewModels.Query_And_Processing;

namespace EZTube.Framework
{
    public interface IViewModelFactory
    {
        QueryBoxViewModel CreateQueryBoxViewModel();
        QueryListViewModel CreateQueryListViewModel();
    }
}
