using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Bootstrap
{
    public class TooltipJsWrapper : JsWrapperBase
    {
        //Constructors
        public TooltipJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
            => "./_content/CoreSharp.Templates.Blazor.Server.WebApp.UI/scripts/bootstrap/tooltip.js";

        //Methods
        public async Task EnableAsync(ElementReference elementReference)
            => await InvokeAsync("enable", elementReference);

        public async Task DisposeAsync(ElementReference elementReference)
            => await InvokeAsync("dispose", elementReference);
    }
}
