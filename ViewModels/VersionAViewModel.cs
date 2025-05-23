using System.Collections.Generic;
using Paints.Models;

namespace Paints.ViewModels;

public class VersionAViewModel(List<Paint> paints) : ViewModelBase
{
    private List<Paint> _paints = paints;
}