using System.ComponentModel.DataAnnotations;

namespace Games.CustomValidations
{
    public class emailAttribute: ValidationAttribute
    {
        private readonly string _email;

        public emailAttribute(string email)
        {
            _email = email;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;
            if (email != null)
            {
                var isallow = email.Split().Contains(_email);
                if (!isallow)
                {
                    return new ValidationResult($"must follow convention: {_email} ");
                }

            }
            return ValidationResult.Success;
        }
    }
}
