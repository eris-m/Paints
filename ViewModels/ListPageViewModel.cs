using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using Paints.Models;

namespace Paints.ViewModels;

public class ListPageViewModel(IEnumerable<PaintStock> paints) : ViewModelBase
{
    private IEnumerable<PaintStock> _paints = paints; 

    public IEnumerable<PaintViewModel> Paints => _paints.Select(PaintViewModelFactory);
    
    public IRelayCommand<PaintViewModel>? SelectPaintCommand { get; set; }

    private PaintViewModel PaintViewModelFactory(PaintStock paintStock)
    {
        var paint = paintStock.Paint;
        
        var viewModel = new PaintViewModel(paint);
        viewModel.SelectCommand = new RelayCommand(() =>
        {
             SelectPaintCommand?.Execute(viewModel);
        });

        return viewModel;
    }
}