using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Paints.Models;

namespace Paints.ViewModels;

public partial class InfoPageViewModel(PaintViewModel? paint, Dictionary<string, PaintStock> paintStocks) : ViewModelBase
{
    [ObservableProperty]
    private PaintViewModel? _paint = paint;

    private Dictionary<string, PaintStock> _paintStocks = paintStocks;

    public uint InStock
    {
        get
        {
            if (Paint == null)
                return 0;
            
            if (!paintStocks.TryGetValue(Paint.Name, out var value))
                return 0;
            return value.Stock;
        }
    }

    public ICommand? ToListCommand { get; set; }
}