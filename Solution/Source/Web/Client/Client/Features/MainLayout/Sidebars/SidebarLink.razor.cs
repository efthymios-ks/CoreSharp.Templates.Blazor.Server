using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.MainLayout.Sidebars
{
    public partial class SidebarLink
    {
        //Properties
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Link { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        //Methods
        private string RelativeUrl
            => NavigationManager.ToBaseRelativePath(NavigationManager.Uri);

        private bool IsActive
            => RelativeUrlsMatch(Link, RelativeUrl);

        private string IsActiveCss
            => IsActive ? "sidebar__link--active" : null;

        //Methods
        private static bool RelativeUrlsMatch(string left, string right)
        {
            static string FormatUrl(string url)
            {
                url ??= string.Empty;
                url = url.Trim(' ', '/');
                url = url.ToLowerInvariant();
                return url;
            }

            left = FormatUrl(left);
            right = FormatUrl(right);
            return left == right;
        }
    }
}
