using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Paints.Models;

namespace Paints.ViewModels;

public class PaintViewModel(Paint paint) : ViewModelBase
{
    public readonly static FuncValueConverter<Color, IBrush> ColourConverter = new(c => new SolidColorBrush(c));

    private Paint _paint = paint;

    public PaintViewModel() : this(new Paint())
    {
    }

    public string Name
    {
        get => _paint.Name;
        set => SetProperty(_paint.Name, value, _paint, (m, v) => m.Name = v);
    }

    public Color Colour
    {
        get => _paint.Colour;
        set => SetProperty(_paint.Colour, value, _paint, (m, v) => m.Colour = value);
    }        
}
