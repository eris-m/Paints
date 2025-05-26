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

    public MainWindowViewModel()
    {
        _listPageViewModel.SelectPaintCommand =
            new RelayCommand<Paint>(SelectPaint, _ => _currentPage == Page.List);

        _infoPageViewModel.ToListCommand = new RelayCommand(ToList);
    }
    
    public ViewModelBase CurrentPage
    {
        get
        {
            if (_currentPage == Page.List)
                return _listPageViewModel;
            return _infoPageViewModel;
        }
    }
    
    private void SelectPaint(Paint? paint)
    {
        _infoPageViewModel.Paint = paint ?? new Paint();
        
        _currentPage = Page.Info;
        OnPropertyChanged(nameof(CurrentPage));
    }

    private void ToList()
    {
        _currentPage = Page.List;
        OnPropertyChanged(nameof(CurrentPage));
    }
}
