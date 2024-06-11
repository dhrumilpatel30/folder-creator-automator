using System.Net;
using Crew_Api_Hostel.API.Exceptions;
using Crew_Api_Hostel.API.Handlers.{{ARG1}}.Create;
using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Repositories.Interfaces;
using Crew_Api_Hostel.API.Utils;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Crew_Api_Hostel.Test.Tests_V1.{{ARG1}}.FunctionalTests;

public class Create{{ARG1}}CommandTests
{
    private readonly Mock<ILogger<Create{{ARG1}}Handler>> _mockLogger = new();
    private readonly Mock<I{{ARG1}}Repository> _mockRepository = new();

    [Fact]
    public async Task Create{{ARG1}}_Should_Return201Created_WhenSucceeded()
    {
        var command = new Create{{ARG1}}Handler(_mockLogger.Object, _mockRepository.Object);
        var {{ARG2}}ToInsert = new Create{{ARG1}}Command
        {
            LoggedInUserId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Create{{ARG1}}Request = new Create{{ARG1}}Request
            {
                HostelId = new Guid("94b903cb-9371-4514-aa1e-a1b66ffcca49"),
                RatingValue = 4.5,
                Date = DateOnly.FromDateTime(DateTime.UtcNow)
            }
        };

        var {{ARG2}}ToGet = new Create{{ARG1}}Response
        {
            Id = Guid.NewGuid()
        };

        var responseObj = new ResponseObj<object>
        {
            StatusCode = HttpStatusCode.Created,
            Status = "Success",
            Time = DateTime.UtcNow,
            Data = {{ARG2}}ToGet
        };

        _mockRepository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Create{{ARG1}}Async({{ARG2}}ToInsert.Create{{ARG1}}Request, new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")))
            .ReturnsAsync(responseObj);

        var result = await command.Handle({{ARG2}}ToInsert, CancellationToken.None);

        result.Should().NotBeNull().And.BeOfType<ResponseObj<object>>();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Create{{ARG1}}_Should_Return500ApplicationError_WhenFailed()
    {
        var command = new Create{{ARG1}}Handler(_mockLogger.Object, _mockRepository.Object);
        var {{ARG2}}ToInsert = new Create{{ARG1}}Command
        {
            LoggedInUserId = new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106"),
            Create{{ARG1}}Request = new Create{{ARG1}}Request
            {
                HostelId = new Guid("94b903cb-9371-4514-aa1e-a1b66ffcca49"),
                RatingValue = 4.5,
                Date = DateOnly.FromDateTime(DateTime.UtcNow)

            }
        };

        _mockRepository.Setup({{ARG2}}Repository => {{ARG2}}Repository.Create{{ARG1}}Async({{ARG2}}ToInsert.Create{{ARG1}}Request, new Guid("d8437944-5350-4f5d-b3b0-98df2b2e4106")))
            .ThrowsAsync(new AppException("Some error"));

        var result = await Assert.ThrowsAsync<AppException>(() => command.Handle({{ARG2}}ToInsert, CancellationToken.None));

        result.Should().NotBeNull();
    }
}