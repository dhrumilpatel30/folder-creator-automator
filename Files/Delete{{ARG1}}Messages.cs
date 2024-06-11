using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Messages.{{ARG1}};

public class Delete{{ARG1}}Request
{
    public Guid {{ARG1}}Id { get; set; }
}

public class Delete{{ARG1}}Command : IRequest<ResponseObj<object>>
{
    public Guid LoggedInUserId { get; set; }

    public required Delete{{ARG1}}Request Delete{{ARG1}}Request { get; set; }
}