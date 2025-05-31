using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Paints.Views;

namespace Paints.Services;

public interface IDialogueService
{
    public Task<uint?> ChangeStock();
    
}

public class DialogueService : IDialogueService
{
    public async Task<uint?> ChangeStock()
    {
        
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