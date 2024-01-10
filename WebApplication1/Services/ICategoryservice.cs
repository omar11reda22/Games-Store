using Microsoft.AspNetCore.Mvc.Rendering;

namespace Games.Services
{
    public interface ICategoryservice
    {
        IEnumerable<SelectListItem> Getcategories();
    }
}
