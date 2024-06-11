using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Messages.{{ARG1}};

public class Update{{ARG1}}Request
{
    public Guid {{ARG1}}Id { get; set; }

    public double RatingValue { get; set; }

}

public class Update{{ARG1}}Command : IRequest<ResponseObj<object>>
{
    public Guid LoggedInUserId { get; set; }

    public required Update{{ARG1}}Request Update{{ARG1}}Request { get; set; }
}

public class Update{{ARG1}}Response
{
    public Guid Id { get; set; }
}