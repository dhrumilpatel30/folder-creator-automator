using System.Net;
using AutoMapper;
using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Models;
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Crew_Api_Hostel.API.Repositories.Services;

public class {{ARG1}}Repository(
    ILogger<{{ARG1}}Repository> logger,
    HostelServiceDbContext db,
    IOptions<AppConfig> appSettings,
    IMapper mapper) : I{{ARG1}}Repository
{
    public async Task<ResponseObj<object>> Create{{ARG1}}Async(Create{{ARG1}}Request {{ARG2}}Command, Guid userId)
    {
        ResponseObj<object> responseObj;
        try
        {
            var isHostelExists = db.Hostels.Any(hostel => hostel.Id == {{ARG2}}Command.HostelId && hostel.IsActive == true);

            if (!isHostelExists)
            {
                responseObj = Common.FailedResponse("Hostel not found", appSettings.Value.Failed!, HttpStatusCode.NotFound);
                return responseObj;
            }

            var is{{ARG1}}Exists = await db.{{ARG1}}s.AnyAsync({{ARG2}} =>
                {{ARG2}}.Date == {{ARG2}}Command.Date && {{ARG2}}.IsActive == true);

            if (is{{ARG1}}Exists)
            {
                responseObj = Common.FailedResponse("{{ARG1}} already exists for given date", appSettings.Value.Failed!,
                    HttpStatusCode.BadRequest);
                return responseObj;
            }

            var {{ARG2}} = new {{ARG1}}
            {
                HostelId = {{ARG2}}Command.HostelId,
                Date = (DateOnly){{ARG2}}Command.Date!,
                RatingValue = Math.Round({{ARG2}}Command.RatingValue, 2),
                IsActive = true
            };
            AuditInfo.SetAuditValues({{ARG2}}, userId, EntityState.Added);
            db.{{ARG1}}s.Add({{ARG2}});
            await db.SaveChangesAsync();

            var {{ARG2}}CommandResponse = new Create{{ARG1}}Response { Id = {{ARG2}}.Id };

            responseObj = Common.SuccessResponse({{ARG2}}CommandResponse, appSettings.Value.Success!, HttpStatusCode.Created);
            return responseObj;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            responseObj = Common.FailedResponse(errorMessage, appSettings.Value.Failed!, HttpStatusCode.InternalServerError);
            return responseObj;
        }
    }

    public async Task<ResponseObj<object>> Update{{ARG1}}Async(Update{{ARG1}}Request {{ARG2}}Command, Guid userId)
    {
        ResponseObj<object> responseObj;
        try
        {
            var {{ARG2}} = await db.{{ARG1}}s.Where({{ARG2}} =>
                {{ARG2}}.Id == {{ARG2}}Command.{{ARG1}}Id && {{ARG2}}.IsActive == true).FirstOrDefaultAsync();

            if ({{ARG2}} == null)
            {
                responseObj = Common.FailedResponse("{{ARG1}} does not exists for given id", appSettings.Value.Failed!,
                    HttpStatusCode.NotFound);
                return responseObj;
            }

            {{ARG2}}.RatingValue = Math.Round({{ARG2}}Command.RatingValue, 2);
            {{ARG2}}.IsActive = true;
            AuditInfo.SetAuditValues({{ARG2}}, userId, EntityState.Modified);
            db.{{ARG1}}s.Update({{ARG2}});
            await db.SaveChangesAsync();

            var {{ARG2}}CommandResponse = new Update{{ARG1}}Response { Id = {{ARG2}}.Id };

            responseObj = Common.SuccessResponse({{ARG2}}CommandResponse, appSettings.Value.Success!, HttpStatusCode.OK);
            return responseObj;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            responseObj = Common.FailedResponse(errorMessage, appSettings.Value.Failed!, HttpStatusCode.InternalServerError);
            return responseObj;
        }
    }

    public async Task<ResponseObj<object>> Delete{{ARG1}}Async(Delete{{ARG1}}Request {{ARG2}}Command, Guid userId)
    {
        ResponseObj<object> responseObj;
        try
        {
            var {{ARG2}} = await db.{{ARG1}}s.Where({{ARG2}} =>
                {{ARG2}}.Id == {{ARG2}}Command.{{ARG1}}Id && {{ARG2}}.IsActive == true).FirstOrDefaultAsync();

            if ({{ARG2}} == null)
            {
                responseObj = Common.FailedResponse("{{ARG1}} does not exists for given id", appSettings.Value.Failed!,
                    HttpStatusCode.NotFound);
                return responseObj;
            }

            {{ARG2}}.IsActive = false;
            AuditInfo.SetAuditValues({{ARG2}}, userId, EntityState.Modified);
            db.{{ARG1}}s.Update({{ARG2}});
            await db.SaveChangesAsync();

            responseObj = Common.SuccessResponse(true, appSettings.Value.Success!, HttpStatusCode.NoContent);
            return responseObj;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            responseObj = Common.FailedResponse(errorMessage, appSettings.Value.Failed!, HttpStatusCode.InternalServerError);
            return responseObj;
        }
    }

    public async Task<ResponseObj<object>> Get{{ARG1}}ByHostelIdAsync(Get{{ARG1}}ByHostelIdRequest {{ARG2}}Query)
    {
        ResponseObj<object> responseObj;
        try
        {
            var isHostelExists = db.Hostels.Any(hostel => hostel.Id == {{ARG2}}Query.HostelId && hostel.IsActive == true);

            if (!isHostelExists)
            {
                responseObj = Common.FailedResponse("Hostel not found", appSettings.Value.Failed!, HttpStatusCode.NotFound);
                return responseObj;
            }

            List<{{ARG1}}> {{ARG2}}s;
            if ({{ARG2}}Query.GetAll)
            {
                {{ARG2}}s = await db.{{ARG1}}s.Where({{ARG2}} =>
                    {{ARG2}}.HostelId == {{ARG2}}Query.HostelId && {{ARG2}}.IsActive == true).ToListAsync();
            }
            else
            {
                {{ARG2}}s = await db.{{ARG1}}s.Where({{ARG2}} =>
                    {{ARG2}}.HostelId == {{ARG2}}Query.HostelId && {{ARG2}}.IsActive == true &&
                    {{ARG2}}Query.Date == {{ARG2}}.Date).ToListAsync();
            }

            if ({{ARG2}}s.Count == 0)
            {
                responseObj = Common.FailedResponse("{{ARG1}} not exists for given hostel id", appSettings.Value.Failed!,
                    HttpStatusCode.NotFound);
                return responseObj;
            }

            var {{ARG2}}QueryResponse = new Get{{ARG1}}ByHostelIdResponse
            {
                HostelId = {{ARG2}}Query.HostelId,
                Date = {{ARG2}}Query.GetAll ? null : {{ARG2}}Query.Date,
                GetAll = {{ARG2}}Query.GetAll,
                {{ARG1}}DetailsList = mapper.Map<List<Get{{ARG1}}ByIdResponse>>({{ARG2}}s)
            };

            responseObj = Common.SuccessResponse({{ARG2}}QueryResponse, appSettings.Value.Success!, HttpStatusCode.Created);
            return responseObj;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            responseObj = Common.FailedResponse(errorMessage, appSettings.Value.Failed!, HttpStatusCode.InternalServerError);
            return responseObj;
        }
    }

    public async Task<ResponseObj<object>> Get{{ARG1}}ByIdAsync(Get{{ARG1}}ByIdRequest {{ARG2}}Query)
    {
        ResponseObj<object> responseObj;
        try
        {
            var {{ARG2}} = await db.{{ARG1}}s.Where({{ARG2}} =>
                {{ARG2}}.Id == {{ARG2}}Query.HosteliteMessRatingId && {{ARG2}}.IsActive == true).FirstOrDefaultAsync();

            if ({{ARG2}} == null)
            {
                responseObj = Common.FailedResponse("{{ARG1}} not exists for given id", appSettings.Value.Failed!, HttpStatusCode.NotFound);
                return responseObj;
            }

            var {{ARG2}}QueryResponse = mapper.Map<Get{{ARG1}}ByIdResponse>({{ARG2}});

            responseObj = Common.SuccessResponse({{ARG2}}QueryResponse, appSettings.Value.Success!, HttpStatusCode.Created);
            return responseObj;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            responseObj = Common.FailedResponse(errorMessage, appSettings.Value.Failed!, HttpStatusCode.InternalServerError);
            return responseObj;
        }
    }
}