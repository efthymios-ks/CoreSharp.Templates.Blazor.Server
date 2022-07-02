using System.Threading.Tasks;
using WebApp.Features.MainLayout.Sidebars;

namespace WebApp.Features.MainLayout;

public partial class AppLayout
{
    //Fields 
    private Sidebar _sidebar;

    //Methods
    private async Task OnSidebarToggleClickedAsync()
        => await _sidebar.OpenAsync();
}
