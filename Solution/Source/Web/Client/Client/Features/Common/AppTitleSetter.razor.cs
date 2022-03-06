using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.Common
{
    public partial class AppTitleSetter
    {
        //Fields
        public const string Key = "Title";

        //Properties
        [Parameter]
        public string Title { get; set; }
    }
}
