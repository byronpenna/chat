using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
namespace Chat.UseCases.Common.Validators
{
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model,
            IEnumerable<IValidator<Model>> validators,
            bool causesException = true
            )
        {
            List<ValidationFailure> Failures = validators.Select(
               v => v.Validate(model)
               ).SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (Failures.Any() && causesException)
            {
                throw new ValidationException(Failures);
                //throw new Exception("X");

            }
            return Task.FromResult(Failures);
        }
    }
}
