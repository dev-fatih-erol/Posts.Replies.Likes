using FluentValidation;
using Posts.Replies.Likes.Application.Commands;

namespace Posts.Replies.Likes.Application.Validators
{
    public class LikeValidator : AbstractValidator<LikeCommand>
    {
        public LikeValidator()
        {
            RuleFor(l => l.User)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(l => l.ReplyId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}