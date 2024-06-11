using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Utils;

namespace Crew_Api_Hostel.API.Repositories.Interfaces;

public interface I{{ARG1}}Repository
{
    public Task<ResponseObj<object>> Create{{ARG1}}Async(Create{{ARG1}}Request {{ARG2}}Command, Guid userId);
    
    public Task<ResponseObj<object>> Update{{ARG1}}Async(Update{{ARG1}}Request {{ARG2}}Command, Guid userId);

    public Task<ResponseObj<object>> Delete{{ARG1}}Async(Delete{{ARG1}}Request {{ARG2}}Command, Guid userId);

    public Task<ResponseObj<object>> Get{{ARG1}}ByHostelIdAsync(Get{{ARG1}}ByHostelIdRequest {{ARG2}}Query);

    public Task<ResponseObj<object>> Get{{ARG1}}ByIdAsync(Get{{ARG1}}ByIdRequest {{ARG2}}Query);
}