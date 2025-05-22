using Avalonia.Media;

namespace Paints.Models;

public class Paint(string name, string brand, Color colour)
{
    public string Name { get; set; } = name;
    public string Brand { get; set; } = brand;
    public Color Colour { get; set; } = colour;
}
