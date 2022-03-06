using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Features.Common.Abstracts
{
    public abstract class ValueComponentBase<TValue> : RazorComponentBase
    {
        //Properties
        [Parameter]
        public TValue Value { get; set; }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        //Methods
        /// <summary>
        /// Compares current with new value.
        /// If different, sets value and raises <see cref="ValueChanged"/>.
        /// </summary>
        protected async Task CompareSetValueAsync(TValue newValue)
        {
            if (Equals(newValue, Value))
                return;

            var parameter = new RazorParameter(nameof(Value), newValue, Value, false, false);
            Value = newValue;
            await ValueChanged.InvokeAsync(Value);
            await OnParametersSetInternalAsync(parameter);
        }
    }
}
