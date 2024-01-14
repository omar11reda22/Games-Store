using Games.CustomValidations;
using Games.Setting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Games.View_Model
{
    public class CreateformaddedGameVM : GameviewModel
    {

      
        //[Allowextention(fileSetting.extentionallow)]
       // [AllowSize(fileSetting.maxallowsize)]
        public IFormFile Cover { get; set; } = default!;
    }
}
