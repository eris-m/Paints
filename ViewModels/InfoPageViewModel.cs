using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Paints.Models;
using Paints.Views;

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

    [RelayCommand]
    private async Task ChangeStock()
    {
        var window = new ChangeStockDialogue();

        var app = App.Current;
        if (app == null)
            return;

        if (app.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
        {
            return;
        }

        var newStock = await window.ShowDialog<uint?>(desktop.MainWindow!);
        if (newStock == null)
            return;
        
        _paintStocks[Paint!.Name].Stock = newStock.Value;
        OnPropertyChanged(nameof(InStock));
    }
}