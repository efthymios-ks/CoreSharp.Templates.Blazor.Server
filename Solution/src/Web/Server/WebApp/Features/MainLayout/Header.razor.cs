using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace WebApp.Features.MainLayout
{
    public partial class Header
    {
        //Properties
        [Parameter]
        public EventCallback SidebarToggleClicked { get; set; }

        //Methods
        private async Task OnSidebarToggleClicked()
            => await SidebarToggleClicked.InvokeAsync();
    }
}
