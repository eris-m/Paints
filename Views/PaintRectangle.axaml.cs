using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Paints.Views;

public class PaintRectangle : TemplatedControl
{
    public static readonly FuncValueConverter<Color, IBrush> ColourConverter = new(c => new SolidColorBrush(c));

    // public new static readonly StyledProperty<IBrush?> BorderBrushProperty =
    //     Border.BorderBrushProperty.AddOwner<PaintRectangle>();
    //
    // public static readonly StyledProperty<Thickness> BorderThicknessProperty =
    //     Border.BorderThicknessProperty.AddOwner<PaintRectangle>();
    
    public static readonly StyledProperty<int> SizeProperty =
        AvaloniaProperty.Register<PaintRectangle, int>(nameof(Size), 100);

    // public static readonly StyledProperty<int> BorderSizeProperty =
    //     AvaloniaProperty.Register<PaintRectangle, int>(nameof(BorderSize), 102);
   
    public static readonly StyledProperty<Color> ColourProperty =
        AvaloniaProperty.Register<PaintRectangle, Color>(nameof(Colour));
    
    public int Size { get; set; }
    public int BorderSize => Size + 2;
    public Color Colour { get; set; }
    
    
}