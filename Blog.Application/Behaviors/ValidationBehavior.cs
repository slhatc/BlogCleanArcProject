using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> validators): IPipelineBehavior<TRequest, TResponse> where TRequest : class
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Any())
                {
                    var errorDetails = failures
                        .GroupBy(f => f.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(f => f.ErrorMessage).ToArray()
                        ).ToList();
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
