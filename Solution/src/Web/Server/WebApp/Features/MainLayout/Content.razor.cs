using Microsoft.AspNetCore.Components;

namespace WebApp.Features.MainLayout;

public partial class Content
{
    //Properties
    [Parameter]
    public RenderFragment ChildContent { get; set; }
}
