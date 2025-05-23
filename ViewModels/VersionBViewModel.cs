using System.Collections.Generic;
using Paints.Models;

namespace Paints.ViewModels;

public class VersionBViewModel(List<Paint> paints) : ViewModelBase
{
    private List<Paint> _paints = paints;
}