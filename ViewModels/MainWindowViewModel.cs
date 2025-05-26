using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Paints.Models;

namespace Paints.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private ListPageViewModel _listPageViewModel = new ListPageViewModel();

    
    public ViewModelBase CurrentPage => _listPageViewModel;
}
