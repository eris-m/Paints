using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Paints.Dialogues;

public partial class ChangeStockDialogue : Window
{
    public ChangeStockDialogue()
    {
        InitializeComponent();
    }

    private void Cancel_OnClick(object? sender, RoutedEventArgs e)
    {
        Close(null);
    }

    private void Set_OnClick(object? sender, RoutedEventArgs e)
    {
        object? value = null;

        var text = TextBox.Text;
        if (text == null)
        {
            Close(null);
            return;
        }

        text = text.Trim('_');
        
        value = uint.Parse(text);
        
        Close(value);
    }
}