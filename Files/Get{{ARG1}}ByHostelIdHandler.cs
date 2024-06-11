using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using Crew_Api_Hostel.API.Validations.{{ARG1}};
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Crew_Api_Hostel.API.Handlers.{{ARG1}}.Get;

public class Get{{ARG1}}ByHostelIdHandler(
    ILogger<Get{{ARG1}}ByHostelIdHandler> logger,
    I{{ARG1}}Repository {{ARG2}}Repository) : IRequestHandler<Get{{ARG1}}ByHostelIdRequest, ResponseObj<object>>
{
    private ILogger Logger { get; } = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<ResponseObj<object>> Handle(Get{{ARG1}}ByHostelIdRequest query, CancellationToken cancellationToken)
    {
        Logger.LogInformation($"Executing {nameof(Get{{ARG1}}ByHostelIdHandler)}");

        var get{{ARG1}}Response = await {{ARG2}}Repository.Get{{ARG1}}ByHostelIdAsync(query);

        return get{{ARG1}}Response;
    }
}