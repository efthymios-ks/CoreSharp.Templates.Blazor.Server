using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.Common
{
    public partial class NavigateTo : ComponentBase
    {
        //Properties
        [Parameter]
        public string Uri { get; set; }

        [Parameter]
        public bool ForceReload { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        //Methods
        protected override void OnInitialized()
        {
            base.OnInitialized();

            NavigationManager.NavigateTo(Uri, ForceReload);
        }
    }
}
