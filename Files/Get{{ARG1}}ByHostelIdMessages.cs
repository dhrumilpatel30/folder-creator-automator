using System.Runtime.InteropServices.JavaScript;
using Crew_Api_Hostel.API.Utils;
using MediatR;

namespace Crew_Api_Hostel.API.Messages.{{ARG1}};

public class Get{{ARG1}}ByHostelIdRequest : IRequest<ResponseObj<object>>
{
    public Guid HostelId { get; set; }

    public DateOnly Date { get; set; }

    public bool GetAll { get; set; }
}

public class Get{{ARG1}}ByHostelIdQueryModel
{
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public bool GetAll { get; set; } = false;
}


public class Get{{ARG1}}ByHostelIdResponse
{
    public Guid? HostelId { get; set; }

    public DateOnly? Date { get; set; }

    public bool GetAll { get; set; }

    public List<Get{{ARG1}}ByIdResponse>? {{ARG1}}DetailsList { get; set; }
}