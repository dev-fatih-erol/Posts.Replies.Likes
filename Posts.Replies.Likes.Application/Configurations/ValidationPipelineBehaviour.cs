using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Posts.Replies.Likes.Application.Configurations
{
    public class ValidationPipelineBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(e => e.Validate(context))
                .SelectMany(e => e.Errors)
                .Where(e => e != null)
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            return next();
        }
    }
}