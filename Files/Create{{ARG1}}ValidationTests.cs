using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Validations.{{ARG1}};
using FluentValidation.TestHelper;
using Xunit;

namespace Crew_Api_Hostel.Test.Tests_V1.{{ARG1}}.ValidationTests;

public class Create{{ARG1}}ValidationTests
{
    [Fact]
    public void Create{{ARG1}}ValidationTests_Should_Error_WhenHostelIdEmpty()
    {
        var validator = new Create{{ARG1}}CommandValidation();

        var request = new Create{{ARG1}}Request
        {
            HostelId = Guid.Empty,
        };

        var result = validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(req => req.HostelId).WithErrorMessage("HostelId is required.");
    }

    [Fact]
    public void Create{{ARG1}}ValidationTests_Should_Error_WhenHostelIdNull()
    {
        var validator = new Create{{ARG1}}CommandValidation();

        var request = new Create{{ARG1}}Request
        {
        };

        var result = validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(req => req.HostelId).WithErrorMessage("HostelId is required.");
    }

}