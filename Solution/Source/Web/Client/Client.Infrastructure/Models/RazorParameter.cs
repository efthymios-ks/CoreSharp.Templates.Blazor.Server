using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Models
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct RazorParameter
    {
        //Constructors
        public RazorParameter(ParameterValue parameter, object previousValue, bool isInitialSet) : this(parameter.Name, previousValue, parameter.Value, parameter.Cascading, isInitialSet)
        {
        }

        public RazorParameter(string name, object previousValue, object currentValue, bool cascading, bool inInitialSet)
        {
            Name = name;
            PreviousValue = previousValue;
            CurrentValue = currentValue;
            Cascading = cascading;
            IsInitialSet = inInitialSet;
        }

        //Properties
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
            => ToString();

        public string Name { get; }

        public object PreviousValue { get; }

        public object CurrentValue { get; }

        public bool Cascading { get; }

        public bool IsInitialSet { get; }

        //Methods
        public override string ToString()
            => Name;
    }
}
