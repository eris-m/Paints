using System;
using Avalonia.Media;

namespace Paints.Models;

public class Paint(string name, string brand, Color colour) : IEquatable<Paint>
{
    public Paint() : this( "" , "" , Colors.Black)
    {}

    public string Name { get; set; } = name;
    public string Brand { get; set; } = brand;
    public Color Colour { get; set; } = colour;

    public bool Equals(Paint? other) => other != null && Name == other.Name;
}

public class PaintStock(Paint paint, uint stock = 0)
{
    public Paint Paint { get; set; } = paint;
    public uint Stock { get; set; } = stock;
}
