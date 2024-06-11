using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using Crew_Api_Hostel.API.Validations.{{ARG1}};
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Crew_Api_Hostel.API.Handlers.{{ARG1}}.Update;

public class Update{{ARG1}}Handler(ILogger<Update{{ARG1}}Handler> logger, I{{ARG1}}Repository {{ARG2}}Repository)
    : IRequestHandler<Update{{ARG1}}Command, ResponseObj<object>>
{
    private ILogger Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<ResponseObj<object>> Handle(Update{{ARG1}}Command command, CancellationToken cancellationToken)
    {
        Logger.LogInformation($"Executing {nameof(Update{{ARG1}}Handler)}");
        var validator = new Update{{ARG1}}CommandValidation();
        var validationResult = await validator.ValidateAsync(command.Update{{ARG1}}Request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var update{{ARG1}}Response =
            await {{ARG2}}Repository.Update{{ARG1}}Async(command.Update{{ARG1}}Request, command.LoggedInUserId);

        return update{{ARG1}}Response;
    }
}