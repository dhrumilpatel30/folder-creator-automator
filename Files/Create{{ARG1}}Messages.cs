using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Messages.{{ARG1}};

public class Create{{ARG1}}Request
{
    public Guid HostelId { get; set; }

    public DateOnly? Date { get; set; }

    public double RatingValue { get; set; }

}

public class Create{{ARG1}}Command : IRequest<ResponseObj<object>>
{
    public Guid LoggedInUserId { get; set; }

    public required Create{{ARG1}}Request Create{{ARG1}}Request { get; set; }
}

public class Create{{ARG1}}Response
{
    public Guid Id { get; set; }
}