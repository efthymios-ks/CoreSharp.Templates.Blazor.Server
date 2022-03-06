using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers.Abstracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers
{
    public class WindowJsWrapper : JsWrapperBase
    {
        //Constructors
        public WindowJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
            => "./scripts/window.js";

        //Methods
        public async Task<(int width, int height)> GetWindowSizeAsync()
        {
            var windowSize = await JSModule.InvokeAsync<WindowSize>("getWindowSize");
            return (windowSize.Width, windowSize.Height);
        }

        public async Task<string> GetRawHtml(ElementReference elementReference)
            => await JSModule.InvokeAsync<string>("getRawHtml", elementReference);

        public async Task<string> GetRawHtml(string elementId)
        {
            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException(nameof(elementId));
            return await JSModule.InvokeAsync<string>("getRawHtmlById", elementId);
        }

        //Nested
        private class WindowSize
        {
            //Properties
            public int Width { get; set; }
            public int Height { get; set; }
        }
    }
}
