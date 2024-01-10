using System.ComponentModel.DataAnnotations;

namespace Games.CustomValidations
{
    public class AllowSizeAttribute:ValidationAttribute
    {
        private readonly int _maxallowsize;

        public AllowSizeAttribute(int maxallowsize)
        {
            _maxallowsize = maxallowsize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxallowsize)
                {
                    return new ValidationResult($"max size allowed is  {_maxallowsize}");
                }
               

            }
            return ValidationResult.Success;
        }
        }
    }
