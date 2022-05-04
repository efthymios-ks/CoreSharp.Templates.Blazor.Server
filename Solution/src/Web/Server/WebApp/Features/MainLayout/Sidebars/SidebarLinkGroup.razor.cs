using Microsoft.AspNetCore.Components;

namespace WebApp.Features.MainLayout.Sidebars
{
    public partial class SidebarLinkGroup
    {
        //Fields  
        private string _currentGroupCs;
        private string _slideGroupContentCss;

        //Properties 
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string SlideGroupLabel { get; set; }

        [Parameter]
        public RenderFragment SlideGroup { get; set; }

        [Parameter]
        public string PreviousText { get; set; } = "Back";

        private bool ShouldShowChildGroupLink
            => !string.IsNullOrEmpty(SlideGroupLabel) && SlideGroup is not null;

        //Methods 
        private void OnSlideGroupInLinkClicked()
            => SlideGroupIn();

        private void OnSlideGroupOutLinkClicked()
            => SlideGroupOut();

        private void SlideGroupOut()
        {
            _currentGroupCs = "slide-in--left";
            _slideGroupContentCss = "slide-out--left";
        }

        private void SlideGroupIn()
        {
            _currentGroupCs = "slide-out--right";
            _slideGroupContentCss = "slide-in--right";
        }
    }
}
