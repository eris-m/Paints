using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Paints.Models;

namespace Paints.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private enum Page
    {
        List,
        Info
    }

    private Page _currentPage = Page.List;
    private ListPageViewModel _listPageViewModel = new ListPageViewModel();
    private InfoPageViewModel _infoPageViewModel = new InfoPageViewModel();

    public ViewModelBase CurrentPage
    {
        get
        {
            if (_currentPage == Page.List)
                return _listPageViewModel;
            return _infoPageViewModel;
        }
    }
}
