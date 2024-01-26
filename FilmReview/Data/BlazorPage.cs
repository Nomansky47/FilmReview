using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilmReview.Data
{
    public static class BlazorPage
    {
        public static Task<IHtmlContent> Render<T>(IHtmlHelper html) where T : IComponent
        {
            return html.RenderComponentAsync<T>(RenderMode.ServerPrerendered);
        }
    }
}
