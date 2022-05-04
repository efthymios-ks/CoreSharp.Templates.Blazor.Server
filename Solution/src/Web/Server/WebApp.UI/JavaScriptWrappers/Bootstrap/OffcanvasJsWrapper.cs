﻿using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Bootstrap
{
    public class OffcanvasJsWrapper : JsWrapperBase
    {
        //Constructors
        public OffcanvasJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
            => "./_content/CoreSharp.Templates.Blazor.Server.WebApp.UI/scripts/bootstrap/offcanvas.js";

        //Methods
        public async Task ShowAsync(ElementReference elementReference)
            => await JSModule.InvokeVoidAsync("show", elementReference);

        public async Task HideAsync(ElementReference elementReference)
            => await JSModule.InvokeVoidAsync("hide", elementReference);

        public async Task ToggleAsync(ElementReference elementReference)
            => await JSModule.InvokeVoidAsync("toggle", elementReference);
    }
}
