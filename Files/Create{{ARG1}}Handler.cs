using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using Crew_Api_Hostel.API.Validations.{{ARG1}};
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Crew_Api_Hostel.API.Handlers.{{ARG1}}.Create;

public class Create{{ARG1}}Handler(ILogger<Create{{ARG1}}Handler> logger, I{{ARG1}}Repository {{ARG2}}Repository)
    : IRequestHandler<Create{{ARG1}}Command, ResponseObj<object>>
{
    private ILogger Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));


    public async Task<ResponseObj<object>> Handle(Create{{ARG1}}Command command, CancellationToken cancellationToken)
    {
        var validator = new Create{{ARG1}}CommandValidation();
        var validationResult = await validator.ValidateAsync(command.Create{{ARG1}}Request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        Logger.LogInformation($"Executing {nameof(Create{{ARG1}}Handler)}");

        var create{{ARG1}}Response = await {{ARG2}}Repository.Create{{ARG1}}Async(command.Create{{ARG1}}Request, command.LoggedInUserId);

        return create{{ARG1}}Response;
    }
}