using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers.Abstracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers
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
            => "./scripts/bootstrap/offcanvas.js";

        //Methods
        public async Task ShowAsync(ElementReference offCanvasReference)
            => await JSModule.InvokeVoidAsync("show", offCanvasReference);

        public async Task HideAsync(ElementReference offCanvasReference)
            => await JSModule.InvokeVoidAsync("hide", offCanvasReference);

        public async Task ToggleAsync(ElementReference offCanvasReference)
            => await JSModule.InvokeVoidAsync("toggle", offCanvasReference);
    }
}
