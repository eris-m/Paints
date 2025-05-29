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
    private Dictionary<string, PaintStock> _paints = []; 
    
    // pages
    private ListPageViewModel _listPageViewModel;
    private InfoPageViewModel _infoPageViewModel;

    public MainWindowViewModel()
    {
        AddPaint(new Paint("Whimsical White", "Eris", Colors.White));
        AddPaint(new Paint("Bulbous Blue", "Eris", Colors.Blue));
        AddPaint(new PaintStock(new Paint("Silly Salamander", "Eris", Colors.LightPink), 1));
        AddPaint(new Paint("Goose Gray", "Eris", Colors.Gray));

        _listPageViewModel = new ListPageViewModel(_paints.Values)
        {
            SelectPaintCommand = new RelayCommand<PaintViewModel>(SelectPaint, _ => _currentPage == Page.List)
        };

        _infoPageViewModel = new InfoPageViewModel(null, _paints)
        {
            ToListCommand = new RelayCommand(ToList)
        };
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
    
    private void SelectPaint(PaintViewModel? paint)
    {
        _infoPageViewModel.Paint = paint ?? new PaintViewModel();
        
        _currentPage = Page.Info;
        OnPropertyChanged(nameof(CurrentPage));
    }

    private void ToList()
    {
        _currentPage = Page.List;
        OnPropertyChanged(nameof(CurrentPage));
    }

    private void AddPaint(PaintStock paint)
    {
        _paints.Add(paint.Paint.Name, paint);
    }

    private void AddPaint(Paint paint)
    {
        _paints.Add(paint.Name, new PaintStock(paint));
    }
}
