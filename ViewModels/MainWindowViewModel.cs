﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Paints.Models;
using Paints.Services;

namespace Paints.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private enum Page
    {
        List,
        Info
    }

    private Page _currentPage = Page.List;
    private PaintList _paints = []; 
    
    // pages
    private ListPageViewModel _listPageViewModel;
    private InfoPageViewModel _infoPageViewModel;

    public MainWindowViewModel()
    {
        AddPaint(new Paint("Whimsical White", "Eris", new PaintColour(255, 255, 255)));
        AddPaint(new Paint("Bulbous Blue", "Eris", new PaintColour(0, 0, 255)));
        AddPaint(new PaintStock(new Paint("Silly Salamander", "Eris", new PaintColour(255, 200, 200)), 1));
        AddPaint(new Paint("Goose Gray", "Eris", new PaintColour(155, 155, 155)));

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

    [RelayCommand]
    private async Task Add()
    {
        var dialogueService = App.Current?.ServiceProvider?.GetService<IDialogueService>();
        if (dialogueService == null)
            return;

        var paint = await dialogueService.CreatePaint();
        if (paint == null)
            return;

        _paints.Add(paint.Name, new PaintStock(paint));
        _listPageViewModel.PaintModels = _paints.Values;
    }

    [RelayCommand]
    private async Task Save()
    {
        var fileService = App.Current?.ServiceProvider?.GetService<IFileService>();
        if (fileService == null)
            return;

        await fileService.SavePaintList(_paints);
    }

    [RelayCommand]
    private async Task Load()
    {
        var fileService = App.Current?.ServiceProvider?.GetService<IFileService>();
        if (fileService == null)
            return;

        var paints = await fileService.LoadPaintList();
        if (paints == null)
            return;

        _paints = paints;
        _infoPageViewModel.PaintStocks = paints;
        _listPageViewModel.PaintModels = paints.Values;
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
