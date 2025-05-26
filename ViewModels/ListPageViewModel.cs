using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using Paints.Models;

namespace Paints.ViewModels;

public class ListPageViewModel : ViewModelBase
{
    private List<Paint> _paints = [
        new Paint("Whimsical White", "Eris", Colors.White),
        new Paint("Bulbous Blue", "Eris", Colors.Blue),
        new Paint("Silly Salamander", "Eris", Colors.LightPink),
        new Paint("Goose Gray", "Eris", Colors.Gray)
    ];

    public IEnumerable<PaintViewModel> Paints => _paints.Select(PaintViewModelFactory);
    
    public IRelayCommand<Paint>? SelectPaintCommand { get; set; }

    private PaintViewModel PaintViewModelFactory(Paint paint)
    {
        var viewModel = new PaintViewModel(paint);
        viewModel.SelectCommand = new RelayCommand(() =>
        {
             SelectPaintCommand?.Execute(viewModel.Paint);
        });

        return viewModel;
    }
}