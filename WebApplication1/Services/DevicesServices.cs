using Games.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Games.Services
{
    public class DevicesServices : IDeviceService
    {
        private readonly Applicationcontext context;

        public DevicesServices(Applicationcontext context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> Getalldevices()
        {
            return context.devices.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name,
            }).OrderBy(s => s.Text).AsNoTracking().ToList();
        }
    }
}
