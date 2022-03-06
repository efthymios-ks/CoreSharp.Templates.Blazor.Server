using CoreSharp.CleanStructure.Blazor.Client.Features.MainLayout.Sidebars;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.MainLayout
{
    public partial class AppLayout : IDisposable
    {
        //Fields 
        private Sidebar _sidebar;

        //Properties
        [Inject]
        protected IAppContextService AppContext { get; set; }

        //Methods
        protected override void OnInitialized()
        {
            base.OnInitialized();

            AppContext.StateHasChangedRequested += AppContextStateHasChangedRequested;
        }

        private async Task OnSidebarToggleClickedAsync()
            => await _sidebar.OpenAsync();

        private void AppContextStateHasChangedRequested()
            => StateHasChanged();

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            AppContext.StateHasChangedRequested -= AppContextStateHasChangedRequested;
        }
    }
}
