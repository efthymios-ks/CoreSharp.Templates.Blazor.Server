using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.JavaScriptWrappers.Abstracts
{
    public abstract class JsWrapperBase : IAsyncDisposable
    {
        //Fields
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IJSRuntime _jsRuntime;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IJSObjectReference _jsModule;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _initialized;

        //Constructors
        protected JsWrapperBase(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
            if (string.IsNullOrWhiteSpace(ModulePath))
                throw new NullReferenceException(nameof(ModulePath));
        }

        //Properties 
        /// <summary>
        /// Module path.
        /// <code>
        /// //Examples
        /// ./scripts/myScript.js
        /// ./_content/scripts/myScript.js
        /// </code>
        /// </summary>
        protected abstract string ModulePath { get; }

        protected IJSObjectReference JSModule
        {
            get => _initialized
                    ? _jsModule
                    : throw new InvalidOperationException($"`{GetType().Name}.{nameof(InitializeAsync)}` has not been called.");
            set => _jsModule = value;
        }

        /// <summary>
        /// Should be called once in <see cref="ComponentBase.OnAfterRenderAsync(bool)"/>
        /// </summary>
        public async Task InitializeAsync()
        {
            if (_initialized)
                return;
            _initialized = true;
            JSModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", ModulePath);
        }

        //Methods
        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return JSModule?.DisposeAsync() ?? default;
        }
    }
}
