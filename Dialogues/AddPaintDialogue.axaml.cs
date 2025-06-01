using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Paints.Models;

namespace Paints.Dialogues;

public partial class AddPaintDialogue : Window
{
    public AddPaintDialogue()
    {
        InitializeComponent();
    }

    private void Cancel_Clicked(object? sender, RoutedEventArgs e)
    {
        Close(null);
    }

    private void Enter_Clicked(object? sender, RoutedEventArgs e)
    {
        var avColour = Picker.Color;
        var colour = new PaintColour(avColour.R, avColour.G, avColour.B, avColour.A);

        var name = NameBox.Text ?? "";
        var brand = BrandBox.Text ?? "";

        var paint = new Paint(name, brand, colour);
        
        Close(paint);
    }
}