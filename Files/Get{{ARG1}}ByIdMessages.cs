using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Messages.{{ARG1}};

public class Get{{ARG1}}ByIdRequest : IRequest<ResponseObj<object>>
{
    public Guid HosteliteMessRatingId { get; set; }

}

public class Get{{ARG1}}ByIdResponse
{
    public Guid? Id { get; set; }

    public Guid HostelId { get; set; }

    public double RatingValue { get; set; }

    public DateOnly Date { get; set; }

    public bool? IsActive { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}