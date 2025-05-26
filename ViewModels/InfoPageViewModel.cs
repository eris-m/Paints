using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Paints.Models;

namespace Paints.ViewModels;

public partial class InfoPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private PaintViewModel _paint;
    
    public ICommand? ToListCommand { get; set; }
}