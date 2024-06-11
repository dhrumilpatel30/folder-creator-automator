using System.Net;
using Crew_Api_Hostel.API.Exceptions;
using Crew_Api_Hostel.API.Handlers.{{ARG1}}.Delete;
using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Crew_Api_Hostel.Test.Tests_V1.{{ARG1}}.FunctionalTests;

public class Delete{{ARG1}}CommandTests
{
    private readonly Mock<ILogger<Delete{{ARG1}}Handler>> _mockLogger = new();
    private readonly Mock<I{{ARG1}}Repository> _mockRepository = new();

    [Fact]
    public async Task Delete{{ARG1}}_Should_Return204NoContent_WhenSucceeded()
    {
        var command = new Delete{{ARG1}}Handler(_mockLogger.Object, _mockRepository.Object);
        var {{ARG2}}ToInsert = new Delete{{ARG1}}Command
        {
            LoggedInUserId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Delete{{ARG1}}Request = new Delete{{ARG1}}Request
            {
                {{ARG1}}Id = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")
            }
        };

        var responseObj = new ResponseObj<object>
        {
            StatusCode = HttpStatusCode.NoContent,
            Status = "Success",
            Time = DateTime.UtcNow,
            Data = true
        };

        _mockRepository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Delete{{ARG1}}Async({{ARG2}}ToInsert.Delete{{ARG1}}Request, new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")))
            .ReturnsAsync(responseObj);

        var result = await command.Handle({{ARG2}}ToInsert, CancellationToken.None);

        result.Should().NotBeNull().And.BeOfType<ResponseObj<object>>();
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Delete{{ARG1}}_Should_Return500ApplicationError_WhenFailed()
    {
        var command = new Delete{{ARG1}}Handler(_mockLogger.Object, _mockRepository.Object);
        var {{ARG2}}ToInsert = new Delete{{ARG1}}Command
        {
            LoggedInUserId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Delete{{ARG1}}Request = new Delete{{ARG1}}Request
            {
                {{ARG1}}Id = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")
            }
        };

        _mockRepository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Delete{{ARG1}}Async({{ARG2}}ToInsert.Delete{{ARG1}}Request, new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")))
            .ThrowsAsync(new AppException("Some error"));

        var result = await Assert.ThrowsAsync<AppException>(() => command.Handle({{ARG2}}ToInsert, CancellationToken.None));

        result.Should().NotBeNull();
    }
}