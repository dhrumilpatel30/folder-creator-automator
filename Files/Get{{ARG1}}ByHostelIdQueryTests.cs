using System.Net;
using Crew_Api_Hostel.API.Exceptions;
using Crew_Api_Hostel.API.Handlers.{{ARG1}}.Get;
using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Crew_Api_Hostel.Test.Tests_V1.{{ARG1}}.FunctionalTests;

public class Get{{ARG1}}ByHostelIdQueryTests
{
    private readonly Mock<ILogger<Get{{ARG1}}ByHostelIdHandler>> _mockLogger = new();
    private readonly Mock<I{{ARG1}}Repository> _mock{{ARG1}}Repository = new();

    [Fact]
    public async Task Get{{ARG1}}ByHostelId_Should_Return200OK_WhenSucceeded()
    {
        var request = new Get{{ARG1}}ByHostelIdRequest
        {
            HostelId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
            GetAll = false
        };

        var responseObj = new ResponseObj<object>
        {
            StatusCode = HttpStatusCode.OK,
            Status = "Success",
            Time = DateTime.UtcNow,
            Data = new Get{{ARG1}}ByHostelIdResponse
            {
                HostelId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                GetAll = false,
                {{ARG1}}DetailsList = new List<Get{{ARG1}}ByIdResponse>
                {
                    new()
                    {
                        RatingValue = 4.5,
                        HostelId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")
                    }
                }
            }
        };

        _mock{{ARG1}}Repository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Get{{ARG1}}ByHostelIdAsync(request))
            .ReturnsAsync(responseObj);
        var query = new Get{{ARG1}}ByHostelIdHandler(_mockLogger.Object, _mock{{ARG1}}Repository.Object);
        var result = await query.Handle(request, CancellationToken.None);

        result.Should().NotBeNull().And.BeOfType<ResponseObj<object>>();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Data.Should().NotBeNull().And.BeOfType<Get{{ARG1}}ByHostelIdResponse>();
    }

    [Fact]
    public async Task Get{{ARG1}}ByHostelId_Should_Return500ApplicationError_WhenFailed()
    {
        var query = new Get{{ARG1}}ByHostelIdHandler(_mockLogger.Object, _mock{{ARG1}}Repository.Object);
        var request = new Get{{ARG1}}ByHostelIdRequest
        {
            HostelId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")
        };
        _mock{{ARG1}}Repository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Get{{ARG1}}ByHostelIdAsync(request))
            .ThrowsAsync(new AppException("Some error"));

        var result = await Assert.ThrowsAsync<AppException>(() => query.Handle(request, CancellationToken.None));

        result.Should().NotBeNull();
    }
}