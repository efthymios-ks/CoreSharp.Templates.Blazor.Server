using CoreSharp.CleanStructure.Blazor.Client.Features.Common;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.MainLayout
{
    public partial class Header
    {
        //Properties
        [Parameter]
        public EventCallback SidebarToggleClicked { get; set; }

        [Inject]
        protected IAppContextService AppContext { get; set; }

        //Methods
        private async Task OnSidebarToggleClicked()
            => await SidebarToggleClicked.InvokeAsync();

        private string GetAppTitle()
        {
            if (!AppContext.Variables.TryGetValue(AppTitleSetter.Key, out var title))
                title = string.Empty;
            return title as string;
        }
    }
}
