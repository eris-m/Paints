using System;
using Avalonia.Media;

namespace Paints.Models;

public record struct PaintColour(byte R, byte G, byte B, byte A)
{
    public PaintColour(byte R, byte G, byte B) : this(R, G, B, 255)
    {
    }
}

public class Paint(string name, string brand, PaintColour colour) : IEquatable<Paint>
{
    public Paint() : this( "" , "" , new PaintColour(0, 0, 0))
    {}

    public string Name { get; set; } = name;
    public string Brand { get; set; } = brand;
    public PaintColour Colour { get; set; } = colour;

    public bool Equals(Paint? other) => other != null && Name == other.Name;
}