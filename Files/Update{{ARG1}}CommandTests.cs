using System.Net;
using Crew_Api_Hostel.API.Exceptions;
using Crew_Api_Hostel.API.Handlers.{{ARG1}}.Update;
using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Crew_Api_Hostel.Test.Tests_V1.{{ARG1}}.FunctionalTests;

public class Update{{ARG1}}CommandTests
{
    private readonly Mock<ILogger<Update{{ARG1}}Handler>> _mockLogger = new();
    private readonly Mock<I{{ARG1}}Repository> _mockRepository = new();

    [Fact]
    public async Task Update{{ARG1}}_Should_Return200OK_WhenSucceeded()
    {
        var command = new Update{{ARG1}}Handler(_mockLogger.Object, _mockRepository.Object);
        var {{ARG2}}ToInsert = new Update{{ARG1}}Command
        {
            LoggedInUserId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Update{{ARG1}}Request = new Update{{ARG1}}Request
            {
                {{ARG1}}Id = new Guid("94b903cb-9371-4514-aa1e-a1b66ffcca49"),
                RatingValue = 4.5
            }
        };

        var {{ARG2}}ToGet = new Update{{ARG1}}Response
        {
            Id = Guid.NewGuid()
        };

        var responseObj = new ResponseObj<object>
        {
            StatusCode = HttpStatusCode.OK,
            Status = "Success",
            Time = DateTime.UtcNow,
            Data = {{ARG2}}ToGet
        };

        _mockRepository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Update{{ARG1}}Async({{ARG2}}ToInsert.Update{{ARG1}}Request, new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")))
            .ReturnsAsync(responseObj);

        var result = await command.Handle({{ARG2}}ToInsert, CancellationToken.None);

        result.Should().NotBeNull().And.BeOfType<ResponseObj<object>>();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Update{{ARG1}}_Should_Return500ApplicationError_WhenFailed()
    {
        var command = new Update{{ARG1}}Handler(_mockLogger.Object, _mockRepository.Object);
        var {{ARG2}}ToInsert = new Update{{ARG1}}Command
        {
            LoggedInUserId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Update{{ARG1}}Request = new Update{{ARG1}}Request
            {
                {{ARG1}}Id = new Guid("94b903cb-9371-4514-aa1e-a1b66ffcca49"),
                RatingValue = 4.5
            }
        };

        _mockRepository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Update{{ARG1}}Async({{ARG2}}ToInsert.Update{{ARG1}}Request, new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")))
            .ThrowsAsync(new AppException("Some error"));

        var result = await Assert.ThrowsAsync<AppException>(() => command.Handle({{ARG2}}ToInsert, CancellationToken.None));

        result.Should().NotBeNull();
    }
}