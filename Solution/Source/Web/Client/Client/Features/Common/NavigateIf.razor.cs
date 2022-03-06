using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.Common
{
    public partial class NavigateIf
    {
        //Properties
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Trigger { get; set; }

        [Parameter]
        public string Uri { get; set; }

        [Parameter]
        public bool ForceReload { get; set; }

        private bool HasNavigateUrl
            => !string.IsNullOrWhiteSpace(Uri);

        private bool ShouldNavigate
            => HasNavigateUrl && Trigger;
    }
}
