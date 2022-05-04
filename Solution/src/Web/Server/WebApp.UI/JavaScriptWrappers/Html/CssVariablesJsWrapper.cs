using CoreSharp.Blazor.JavaScriptWrappers.Common;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebApp.UI.JavaScriptWrappers.Html
{
    public class CssVariablesJsWrapper : JsWrapperBase
    {
        //Constructors
        public CssVariablesJsWrapper(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
        }

        //Properties
        protected override string ModulePath
            => "./_content/CoreSharp.Templates.Blazor.Server.WebApp.UI/scripts/html/cssVariables.js";

        //Methods
        public async Task<string> GetAsync(string key)
            => await JSModule.InvokeAsync<string>("get", key);

        public async Task<string> SetAsync(string key, string value)
            => await JSModule.InvokeAsync<string>("set", key, value);

        public async Task<string> SetAsync(string key, object value)
            => await SetAsync(key, $"{value}");
    }
}
