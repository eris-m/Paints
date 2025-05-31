using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Paints.Models;
using Paints.Services;
using Microsoft.Extensions.DependencyInjection;
using Paints.Views;

namespace Paints.ViewModels;

public partial class InfoPageViewModel(PaintViewModel? paint, PaintList paintStocks) : ViewModelBase
{
    [ObservableProperty]
    private PaintViewModel? _paint = paint;

    private PaintList _paintStocks = paintStocks;

    public PaintList PaintStocks
    {
        set
        {
            _paintStocks = value;
            OnPropertyChanged(nameof(InStock));
        }
    }
    
    public uint InStock
    {
        get
        {
            if (Paint == null)
                return 0;
            
            if (!_paintStocks.TryGetValue(Paint.Name, out var value))
                return 0;
            return value.Stock;
        }
    }

    public ICommand? ToListCommand { get; set; }

    [RelayCommand]
    private async Task ChangeStock()
    {
        var dialogueService = App.Current?.ServiceProvider?.GetService<IDialogueService>();
        if (dialogueService == null)
            return;

        var newStock = await dialogueService.ChangeStock();
        if (newStock == null)
            return;
        
        _paintStocks[Paint!.Name].Stock = newStock.Value;
        OnPropertyChanged(nameof(InStock));
    }
}