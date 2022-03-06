using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Linq;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Features.Common.Abstracts
{
    public abstract class InputComponentBase<TValue> : ValueComponentBase<TValue>
    {
        //Properties 
        [Parameter]
        public bool ReadOnly { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected string ReadOnlyCss
            => HasBaseCss && ReadOnly ? $"{BaseCss}--readonly" : string.Empty;

        //Methods 
        internal override string GetCssClasses(params string[] additionalCss)
            => base.GetCssClasses(new[] { ReadOnlyCss }.Concat(additionalCss).ToArray());
    }
}
