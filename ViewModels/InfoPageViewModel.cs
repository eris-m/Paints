using CommunityToolkit.Mvvm.ComponentModel;
using Paints.Models;

namespace Paints.ViewModels;

public partial class InfoPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private Paint _paint = new();
    
    
}