using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Handlers.{{ARG1}}.Delete;

public class Delete{{ARG1}}Handler(ILogger<Delete{{ARG1}}Handler> logger, I{{ARG1}}Repository {{ARG2}}Repository)
    : IRequestHandler<Delete{{ARG1}}Command, ResponseObj<object>>
{
    private ILogger Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<ResponseObj<object>> Handle(Delete{{ARG1}}Command command, CancellationToken cancellationToken)
    {
        Logger.LogInformation($"Executing {nameof(Delete{{ARG1}}Handler)}");

        var delete{{ARG1}}Response = await {{ARG2}}Repository.Delete{{ARG1}}Async(command.Delete{{ARG1}}Request, command.LoggedInUserId);

        return delete{{ARG1}}Response;
    }
}