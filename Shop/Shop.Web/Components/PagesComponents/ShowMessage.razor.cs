using Microsoft.AspNetCore.Components;

namespace Shop.Web.Components.PagesComponents
{
    public partial class ShowMessage
    {
        [Parameter] public bool IsShowMessage { get; set; }

        [Parameter] public bool IsSuccess { get; set; }

        [Parameter] public string MessageText { get; set; } = string.Empty;
    }
}
