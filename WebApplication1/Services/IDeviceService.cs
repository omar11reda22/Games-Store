using Microsoft.AspNetCore.Mvc.Rendering;

namespace Games.Services
{
    public interface IDeviceService
    {
        IEnumerable<SelectListItem> Getalldevices();
    }
}
