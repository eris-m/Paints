using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using Paints.Models;

namespace Paints.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private List<Paint> _paints = [
        new Paint("Whimsical White", "Eris", Colors.White),
        new Paint("Bulbous Blue", "Eris", Colors.Blue),
        new Paint("Silly Salamander", "Eris", Colors.LightPink)
    ];

    public IEnumerable<PaintViewModel> Paints => _paints.Select(p => new PaintViewModel(p));
}
