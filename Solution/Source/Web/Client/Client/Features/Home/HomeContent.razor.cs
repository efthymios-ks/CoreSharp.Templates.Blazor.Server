using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.Home
{
    public partial class HomeContent : IAsyncDisposable
    {
        //Fields
        private int _counter;

        //Properties
        [Inject]
        protected WindowJsWrapper WindowJsWrapper { get; set; }

        //Methods
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
                await WindowJsWrapper.InitializeAsync();
        }

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return WindowJsWrapper.DisposeAsync();
        }

        private void OnDownloadFileClicked()
        {
            _counter++;
            DownloadFile();
        }

        private async Task OnDownloadFileClickedAsync()
        {
            _counter++;
            await DownloadFileAsync();
        }

        private async Task OnGetWindowSizeClickedAsync()
            => await WindowJsWrapper.GetWindowSizeAsync();

        private static void DownloadFile()
            => Thread.Sleep(TimeSpan.FromSeconds(10));

        private static async Task DownloadFileAsync()
            => await Task.Delay(TimeSpan.FromSeconds(10));
    }
}
