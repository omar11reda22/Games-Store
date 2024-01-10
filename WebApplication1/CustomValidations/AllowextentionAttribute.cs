using System.ComponentModel.DataAnnotations;

namespace Games.CustomValidations
{
    public class AllowextentionAttribute: ValidationAttribute
    {
        private readonly string _allowExtention;
        public AllowextentionAttribute( string allowExtention)
        {
            this._allowExtention = allowExtention;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var File = value as IFormFile;
            if (File != null)
            {
                var extention = Path.GetExtension(File.FileName);
                var isallow = _allowExtention.Split(',').Contains(extention , StringComparer.OrdinalIgnoreCase);
                if (!isallow) { return new ValidationResult($"only allow {_allowExtention}"); }

            }
            return ValidationResult.Success;
        }



    }
}
