using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Bootstrap
{
    public class DropdownJsWrapper : JsWrapperBase
    {
        //Constructors
        public DropdownJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
             => "./_content/CoreSharp.Templates.Blazor.Server.WebApp.UI/scripts/bootstrap/dropdown.js";

        //Methods 
        public async Task ShowAsync(ElementReference dropdownToggleReference)
            => await JSModule.InvokeVoidAsync("show", dropdownToggleReference);

        public async Task HideAsync(ElementReference dropdownToggleReference)
            => await JSModule.InvokeVoidAsync("hide", dropdownToggleReference);
    }
}
