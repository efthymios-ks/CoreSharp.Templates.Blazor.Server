using CoreSharp.Blazor.JavaScriptWrappers.Common;
using CoreSharp.Delegates;
using CoreSharp.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Html
{
    public class KeyboardListenerJsWrapper : JsWrapperBase
    {
        //Constructors
        public KeyboardListenerJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Events
        public event AsyncAction<KeyboardEventArgs> KeyDown;

        //Properties
        protected override string ModulePath
            => "./_content/CoreSharp.Templates.Blazor.Server.WebApp.UI/scripts/html/keyboardListener.js";

        public async Task SubscribeAsync()
            => await InvokeAsync("addKeydownListener", DotNetObjectReference.Create(this), nameof(OnKeyDownAsync));

        [JSInvokable]
        public async Task OnKeyDownAsync(KeyboardEventArgs args)
        {
            if (KeyDown is null)
                return;

            await KeyDown.InvokeAsync(args);
        }
    }
}
