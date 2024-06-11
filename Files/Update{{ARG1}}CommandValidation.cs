using Crew_Api_Hostel.API.Messages.{{ARG1}};
using FluentValidation;

namespace Crew_Api_Hostel.API.Validations.{{ARG1}};

public class Update{{ARG1}}CommandValidation : AbstractValidator<Update{{ARG1}}Request>
{
    public Update{{ARG1}}CommandValidation()
    {
        RuleFor({{ARG2}}Command => {{ARG2}}Command.{{ARG1}}Id).NotNull().NotEmpty()
            .WithMessage("{{ARG1}}Id is required.");
        RuleFor({{ARG2}}Command => {{ARG2}}Command.RatingValue).NotNull().WithMessage("RatingValue is required.");
        RuleFor({{ARG2}}Command => {{ARG2}}Command.RatingValue).InclusiveBetween(1, 5)
            .WithMessage("RatingValue should be between 1 and 5.");
    }
}