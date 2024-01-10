using Games.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Games.Services
{
    
    public class CategoryService : ICategoryservice
    {
        private readonly Applicationcontext context;

        public CategoryService(Applicationcontext context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> Getcategories()
        {
            return context.categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).OrderBy(s => s.Text).AsNoTracking().ToList();
        }
    }
}
