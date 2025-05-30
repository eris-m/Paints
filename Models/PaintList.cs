using System.Collections.Generic;

namespace Paints.Models;

public class PaintStock(Paint paint, uint stock = 0)
{
    public Paint Paint { get; set; } = paint;
    public uint Stock { get; set; } = stock;
}

public class PaintList : Dictionary<string, PaintStock>;