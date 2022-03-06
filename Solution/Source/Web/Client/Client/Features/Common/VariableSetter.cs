using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Features.Common.Abstracts;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.Common
{
    public class VariableSetter : RazorComponentBase
    {
        //Properties
        [Inject]
        protected IAppContextService AppContext { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public object Value { get; set; }

        //Methods
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            var hasKey = !string.IsNullOrEmpty(Key);
            if (hasKey)
            {
                var variables = AppContext.Variables;
                if (variables.ContainsKey(Key))
                    variables[Key] = Value;
                else
                    variables.Add(Key, Value);
            }
        }
    }
}
