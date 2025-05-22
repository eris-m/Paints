using Avalonia.Media;
using Paints.Models;

namespace Paints.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public PaintViewModel Paint => new PaintViewModel(new Paint("Corvax", "Citadel", Colors.White));
}
