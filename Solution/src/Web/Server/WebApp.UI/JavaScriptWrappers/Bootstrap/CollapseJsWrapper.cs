﻿using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Bootstrap
{
    public class CollapseJsWrapper : JsWrapperBase
    {
        //Constructors
        public CollapseJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
             => "./_content/CoreSharp.Templates.Blazor.Server.WebApp.UI/scripts/bootstrap/collapse.js";

        //Methods
        public async Task ShowAsync(ElementReference elementReference)
            => await InvokeAsync("show", elementReference);

        public async Task HideAsync(ElementReference elementReference)
            => await InvokeAsync("hide", elementReference);

        public async Task ToggleAsync(ElementReference elementReference)
            => await InvokeAsync("toggle", elementReference);
    }
}
