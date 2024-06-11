using Crew_Api_Hostel.API.Messages.{{ARG1}};
using FluentValidation;

namespace Crew_Api_Hostel.API.Validations.{{ARG1}};

public class Create{{ARG1}}CommandValidation : AbstractValidator<Create{{ARG1}}Request>
{
    public Create{{ARG1}}CommandValidation()
    {
        RuleFor({{ARG2}}Command => {{ARG2}}Command.HostelId).NotNull().NotEmpty().WithMessage("HostelId is required.");
        RuleFor({{ARG2}}Command => {{ARG2}}Command.Date).NotNull().WithMessage("Date is required.");
    }
}