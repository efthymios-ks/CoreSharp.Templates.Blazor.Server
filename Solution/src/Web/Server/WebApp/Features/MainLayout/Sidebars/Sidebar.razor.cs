using CoreSharp.Blazor.JavaScriptWrappers.Bootstrap;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace WebApp.Features.MainLayout.Sidebars
{
    public partial class Sidebar : IAsyncDisposable
    {
        //Fields 
        private ElementReference _offcanvasReference;

        //Properties
        [Inject]
        protected OffcanvasJsWrapper OffcanvasJsWrapper { get; set; }

        //Methods 
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
                await OffcanvasJsWrapper.InitializeAsync();
        }

        public async Task OpenAsync()
            => await OffcanvasJsWrapper.ToggleAsync(_offcanvasReference);

        public async Task CloseAsync()
            => await OffcanvasJsWrapper.HideAsync(_offcanvasReference);

        public async Task ToggleAsync()
            => await OffcanvasJsWrapper.ToggleAsync(_offcanvasReference);

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return OffcanvasJsWrapper.DisposeAsync();
        }
    }
}
