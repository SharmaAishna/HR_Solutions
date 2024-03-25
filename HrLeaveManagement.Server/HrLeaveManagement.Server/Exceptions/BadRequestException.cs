using FluentValidation.Results;

namespace HrLeaveManagement.Server.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();

            //ValidationErrors = new();
            //foreach (var error in validationResult.Errors)
            //{
            //    ValidationErrors.Add(error.ErrorMessage);
            //}
        }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
