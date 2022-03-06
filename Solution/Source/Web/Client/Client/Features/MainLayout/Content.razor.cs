using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.MainLayout
{
    public partial class Content
    {
        //Properties
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
