using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Paints.Models;
using Paints.Views;

namespace Paints.Services;

public interface IDialogueService
{
    public Task<uint?> ChangeStock();
    public Task<Paint?> CreatePaint();
}

public class DialogueService : IDialogueService
{
    public async Task<uint?> ChangeStock()
    {
        var window = new ChangeStockDialogue();

        var newStock = await window.ShowDialog<uint?>(MainWindow()!);
        return newStock;
    }

    public async Task<Paint?> CreatePaint()
    {
        var window = new AddPaintDialogue();

        var newPaint = await window.ShowDialog<Paint?>(MainWindow()!);
        return newPaint;
    }

    private Window? MainWindow()
    {
        var app = App.Current;

        if (app?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
            return null;

        return desktop.MainWindow;
        
        var window = new ChangeStockDialogue();

        var app = App.Current;

        if (app?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
        {
            return null;
        }

        var newStock = await window.ShowDialog<uint?>(desktop.MainWindow!);
        return newStock;
    }
}