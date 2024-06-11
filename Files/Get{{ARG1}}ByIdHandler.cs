using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Handlers.{{ARG1}}.Get;

public class Get{{ARG1}}ByIdHandler(ILogger<Get{{ARG1}}ByIdHandler> logger, I{{ARG1}}Repository {{ARG2}}Repository)
    : IRequestHandler<Get{{ARG1}}ByIdRequest, ResponseObj<object>>
{
    private ILogger Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<ResponseObj<object>> Handle(Get{{ARG1}}ByIdRequest query, CancellationToken cancellationToken)
    {
        Logger.LogInformation($"Executing {nameof(Get{{ARG1}}ByIdHandler)}");

        var get{{ARG1}}Response = await {{ARG2}}Repository.Get{{ARG1}}ByIdAsync(query);

        return get{{ARG1}}Response;
    }
}