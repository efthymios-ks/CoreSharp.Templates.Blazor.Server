using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Models;
using CoreSharp.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Features.Common.Abstracts
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class RazorComponentBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        //Fields
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ConcurrentDictionary<string, object> _parameters = new();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly Regex _multiWhitespaceSelectRegex = new(@"\s+");

        //Properties 
        /// <summary>
        /// The HTML id attribute is used to specify a unique id for an HTML element.
        /// You cannot have more than one element with the same id in an HTML document.
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Whether the <see cref="Microsoft.AspNetCore.Components.ComponentBase"/> should be visible or not.
        /// Has to be implemented by user.
        /// <code>
        /// @if (Visible)
        /// {
        ///     &lt;input id="@Id"/&gt;
        /// }
        /// </code>
        /// </summary>
        [Parameter]
        public bool Visible { get; set; } = true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
            => Id;

        /// <inheritdoc cref="ElementReference"/>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected ElementReference Element { get; set; }

        /// <summary>
        /// <see cref="Microsoft.AspNetCore.Components.ComponentBase"/> css class.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual string BaseCss { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal bool HasBaseCss
            => !string.IsNullOrWhiteSpace(nameof(BaseCss));

        //Methods
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender && string.IsNullOrWhiteSpace(Id))
            {
                Id = Guid.NewGuid().ToString();
                StateHasChanged();
            }
        }

        /// <summary>
        /// Build final css classes collection.
        /// </summary>
        internal virtual string GetCssClasses(params string[] additionalCss)
        {
            _ = additionalCss ?? throw new ArgumentNullException(nameof(additionalCss));

            if (additionalCss.Length == 0)
                return BaseCss;

            var builder = new StringBuilder();
            //Base css
            builder.Append(BaseCss).Append(' ');
            //Additional css
            foreach (var css in additionalCss)
                builder.Append(css).Append(' ');
            //Build and return 
            var finalCss = builder.ToString().Trim();
            return TrimMultiWhitespace(finalCss);
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var changedParameters = new HashSet<RazorParameter>();

            //Set parameters buffer 
            foreach (var parameter in parameters)
            {
                var key = parameter.Name;
                var currentValue = parameter.Value;

                //Update 
                if (_parameters.TryGetValue(key, out var previousValue))
                {
                    _parameters.TryUpdate(key, currentValue, previousValue);

                    var isRenderFragment = currentValue is not null && IsTypeRenderFragment(currentValue.GetType());
                    if (isRenderFragment || !Equals(currentValue, previousValue))
                        changedParameters.Add(new(parameter, previousValue, false));
                }
                //Add 
                else
                {
                    var defaultValue = currentValue?.GetType().GetDefault();
                    _parameters.TryAdd(key, currentValue);
                    changedParameters.Add(new(parameter, defaultValue, true));
                }
            }

            //Set after work is done to avoid synchronization exceptions 
            await base.SetParametersAsync(parameters);

            //Notify 
            await OnParametersSetInternalAsync(changedParameters.ToArray());
        }

        /// <summary>
        /// SHOULD BE NEVER EXPOSED TO OUTER CODE.
        /// Used for internal purposes.
        /// Always call base implementation in the end.
        /// <code>
        /// protected override async Task OnParametersSetInternalAsync(RazorParameter[] parameters)
        /// {
        ///     // Your logic
        ///     // ...
        ///     // Then base call
        ///     await base.OnParametersSetInternalAsync(parameters);
        /// }
        /// </code>
        /// </summary>
        internal virtual async Task OnParametersSetInternalAsync(params RazorParameter[] parameters)
        {
            _ = parameters ?? throw new ArgumentNullException(nameof(parameters));

            if (parameters.Length == 0)
                return;

            await OnParametersSetAsync(parameters);
        }

        /// <inheritdoc cref="Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync"/>
        protected virtual Task OnParametersSetAsync(RazorParameter[] parameters)
            => Task.CompletedTask;

        private static string TrimMultiWhitespace(string value)
            => _multiWhitespaceSelectRegex.Replace(value ?? string.Empty, " ");

        private static bool IsTypeRenderFragment(Type type)
        {
            _ = type ?? throw new ArgumentNullException(nameof(type));

            var renderFragmentTypes = new[] { typeof(RenderFragment), typeof(RenderFragment<>) };
            var parameterType = type.GetNullableBaseType().GetGenericTypeBase();
            return renderFragmentTypes.Any(t => t == parameterType);
        }
    }
}
