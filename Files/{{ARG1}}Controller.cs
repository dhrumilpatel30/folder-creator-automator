using System.Net;
using System.Security.Claims;
using Crew_Api_Hostel.API.Authorize;
using Crew_Api_Hostel.API.Exceptions;
using Crew_Api_Hostel.API.Messages.{{ARG1}};
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crew_Api_Hostel.API.Controllers;

[ApiController]
[Route("api/Hostel/[controller]")]
public class {{ARG1}}Controller(IMediator mediator) : ControllerBase
{
    private IMediator Mediator { get; } = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [AuthorizationHandler("Super Admin", "Admin", "Warden")]
    [HttpPost]
    [ProducesResponseType(typeof(Create{{ARG1}}Response), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create{{ARG1}}([FromBody] Create{{ARG1}}Request create{{ARG1}}Request,
        CancellationToken cancellationToken)
    {
        var user = HttpContext.Items["User"] as ClaimsPrincipal;
        var userIdClaim = user?.FindFirst("UserId")?.Value;
        var userId = userIdClaim != null ? new Guid(userIdClaim) : Guid.Empty;

        var create{{ARG1}}Command = new Create{{ARG1}}Command
        {
            Create{{ARG1}}Request = create{{ARG1}}Request,
            LoggedInUserId = userId
        };

        var response = await Mediator.Send(create{{ARG1}}Command, cancellationToken);

        if (response.Status == "Failed")
        {
            var errorMessage = response.Data!.ToString();
            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ConflictException(errorMessage!);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(errorMessage!);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(errorMessage!);
                case HttpStatusCode.InternalServerError:
                    throw new AppException(errorMessage!);
            }
        }

        return new OkObjectResult(response);
    }
    
    [AuthorizationHandler("Super Admin", "Admin", "Warden")]
    [HttpPut]
    [ProducesResponseType(typeof(Update{{ARG1}}Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update{{ARG1}}([FromBody] Update{{ARG1}}Request update{{ARG1}}Request,
        CancellationToken cancellationToken)
    {
        var user = HttpContext.Items["User"] as ClaimsPrincipal;
        var userIdClaim = user?.FindFirst("UserId")?.Value;
        var userId = userIdClaim != null ? new Guid(userIdClaim) : Guid.Empty;

        var update{{ARG1}}Command = new Update{{ARG1}}Command
        {
            Update{{ARG1}}Request = update{{ARG1}}Request,
            LoggedInUserId = userId
        };

        var response = await Mediator.Send(update{{ARG1}}Command, cancellationToken);

        if (response.Status == "Failed")
        {
            var errorMessage = response.Data!.ToString();
            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ConflictException(errorMessage!);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(errorMessage!);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(errorMessage!);
                case HttpStatusCode.InternalServerError:
                    throw new AppException(errorMessage!);
            }
        }

        return new OkObjectResult(response);
    }

    [AuthorizationHandler("Super Admin", "Admin", "Warden")]
    [HttpDelete("{{{ARG2}}Id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete{{ARG1}}(Guid {{ARG2}}Id, CancellationToken cancellationToken)
    {
        var user = HttpContext.Items["User"] as ClaimsPrincipal;
        var userIdClaim = user?.FindFirst("UserId")?.Value;
        var userId = userIdClaim != null ? new Guid(userIdClaim) : Guid.Empty;

        var delete{{ARG1}}Command = new Delete{{ARG1}}Command
        {
            Delete{{ARG1}}Request = new Delete{{ARG1}}Request { {{ARG1}}Id = {{ARG2}}Id },
            LoggedInUserId = userId
        };

        var response = await Mediator.Send(delete{{ARG1}}Command, cancellationToken);

        if (response.Status == "Failed")
        {
            var errorMessage = response.Data!.ToString();
            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ConflictException(errorMessage!);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(errorMessage!);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(errorMessage!);
                case HttpStatusCode.InternalServerError:
                    throw new AppException(errorMessage!);
            }
        }

        return new NoContentResult();
    }

    [AuthorizationHandler("Super Admin", "Admin", "Warden")]
    [HttpGet("ByHostelId/{hostelId:guid}")]
    [ProducesResponseType(typeof(Get{{ARG1}}ByHostelIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get{{ARG1}}ByHostelId([FromRoute] Guid hostelId, [FromQuery] Get{{ARG1}}ByHostelIdQueryModel query, CancellationToken cancellationToken)
    {
        var request = new Get{{ARG1}}ByHostelIdRequest
        {
            HostelId = hostelId,
            Date = query.Date,
            GetAll = query.GetAll
        };

        var response = await Mediator.Send(request, cancellationToken);

        if (response.Status == "Failed")
        {
            var errorMessage = response.Data!.ToString();
            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ConflictException(errorMessage!);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(errorMessage!);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(errorMessage!);
                case HttpStatusCode.InternalServerError:
                    throw new AppException(errorMessage!);
            }
        }

        return new OkObjectResult(response);
    }


    [AuthorizationHandler("Super Admin", "Admin", "Warden")]
    [HttpGet("{{{ARG2}}Id:guid}")]
    [ProducesResponseType(typeof(Get{{ARG1}}ByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get{{ARG1}}ById([FromRoute] Guid {{ARG2}}Id, CancellationToken cancellationToken)
    {
        var request = new Get{{ARG1}}ByIdRequest
        {
            HosteliteMessRatingId = {{ARG2}}Id
        };

        var response = await Mediator.Send(request, cancellationToken);

        if (response.Status == "Failed")
        {
            var errorMessage = response.Data!.ToString();
            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ConflictException(errorMessage!);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(errorMessage!);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(errorMessage!);
                case HttpStatusCode.InternalServerError:
                    throw new AppException(errorMessage!);
            }
        }

        return new OkObjectResult(response);
    }
}