using Games.CustomValidations;
using Games.Setting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Games.View_Model
{
    public class CreateformaddedGameVM
    {

        [MaxLength(250)]
        [email(fileSetting.l)]
        public string Name { get; set; } = string.Empty;

        [Display(Name ="Categories")]
        public int categoryID { get; set; }
        public IEnumerable<SelectListItem> Categories {  get; set; } = Enumerable.Empty<SelectListItem>();

        public IList<int> selecteddevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(3000)]
        [Required]
        public string Discreption { get; set; } = string.Empty;
        [Allowextention(fileSetting.extentionallow)]
        [AllowSize(fileSetting.maxallowsize)]
        public IFormFile Cover { get; set; } = default!;
    }
}
