using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers.Abstracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers
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
            => "./scripts/bootstrap/collapse.js";

        //Methods
        public async Task ShowAsync(ElementReference collapsibleReference)
            => await JSModule.InvokeVoidAsync("show", collapsibleReference);

        public async Task HideAsync(ElementReference collapsibleReference)
            => await JSModule.InvokeVoidAsync("hide", collapsibleReference);

        public async Task ToggleAsync(ElementReference collapsibleReference)
            => await JSModule.InvokeVoidAsync("toggle", collapsibleReference);
    }
}
