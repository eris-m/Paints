using System;
using System.Globalization;
using System.Windows.Input;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Media;
using Paints.Models;

namespace Paints.ViewModels;

public class PaintViewModel(Paint paint) : ViewModelBase
{
    private Paint _paint = paint;
    
    public ICommand? SelectCommand { get; set; }
    public PaintViewModel() : this(new Paint())
    {
    }

    public Paint Paint
    {
        get => _paint;
        set
        {
            SetProperty(ref _paint, value);
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Brand));
            OnPropertyChanged(nameof(Colour));
        }
    }

    public string Name
    {
        get => Paint.Name;
        set => SetProperty(Paint.Name, value, Paint, (m, v) => m.Name = v);
    }

    public string Brand
    {
        get => Paint.Brand;
        set => SetProperty(Paint.Brand, value, Paint, (p, s) => p.Brand = s);
    }

    public Color Colour
    {
        get => ConvertColour(Paint.Colour);
        set => SetProperty(
            ConvertColour(Paint.Colour), 
            value, 
            Paint, 
            (m, v) => m.Colour = ConvertColour(value)
        );
    }

    private static Color ConvertColour(PaintColour colour)
    {
        return new Color(colour.A, colour.R, colour.G, colour.B);
    }

    private static PaintColour ConvertColour(Color colour)
    {
        return new PaintColour(colour.R, colour.G, colour.B, colour.A);
    }
}
