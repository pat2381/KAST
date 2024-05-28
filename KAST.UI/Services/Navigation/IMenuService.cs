using KAST.UI.Models.NavigationMenu;
using System.Collections.Generic;

namespace KAST.UI.Services.Navigation;

public interface IMenuService
{
    IEnumerable<MenuSectionModel> Features { get; }
}