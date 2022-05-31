using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Html
{
    public class DomElementsJsWrapper : JsWrapperBase
    {
        //Constructors
        public DomElementsJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
            => "./scripts/html/domElements.js";

        //Methods
        public async Task<IDictionary<string, string>> GetPropertiesAsync(ElementReference elementReference, params string[] keys)
        {
            var args = new object[] { elementReference }.Concat(keys)
                                                        .ToArray();
            return await InvokeAsync<IDictionary<string, string>>("getProperties", args);
        }

        public async Task<string> GetRawHtml(string elementId)
        {
            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException(nameof(elementId));
            return await InvokeAsync<string>("getRawHtmlById", elementId);
        }

        public async Task<string> GetRawHtml(ElementReference elementReference)
            => await InvokeAsync<string>("getRawHtml", elementReference);

        public async Task ScrollIntoViewAsync(string elementId)
        {
            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException(nameof(elementId));
            await InvokeAsync("scrollIntoViewById", elementId);
        }

        public async Task ScrollIntoViewAsync(ElementReference elementReference)
            => await InvokeAsync("scrollIntoView", elementReference);
    }
}
