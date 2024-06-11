using Crew_Api_Hostel.API.Messages.{{ARG1}};
using Crew_Api_Hostel.API.Validations.{{ARG1}};
using FluentValidation.TestHelper;
using Xunit;

namespace Crew_Api_Hostel.Test.Tests_V1.{{ARG1}}.ValidationTests;

public class Update{{ARG1}}ValidationTests
{
    [Fact]
    public void Update{{ARG1}}ValidationTests_Should_Error_When{{ARG1}}IdEmpty()
    {
        var validator = new Update{{ARG1}}CommandValidation();

        var request = new Update{{ARG1}}Request
        {
            {{ARG1}}Id = Guid.Empty,
        };

        var result = validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(req => req.{{ARG1}}Id).WithErrorMessage("{{ARG1}}Id is required.");
    }

    [Fact]
    public void Update{{ARG1}}ValidationTests_Should_Error_When{{ARG1}}IdNull()
    {
        var validator = new Update{{ARG1}}CommandValidation();

        var request = new Update{{ARG1}}Request
        {
        };

        var result = validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(req => req.{{ARG1}}Id).WithErrorMessage("{{ARG1}}Id is required.");
    }

    [Fact]
    public void Update{{ARG1}}ValidationTests_Should_Error_WhenRatingValueIsInValid()
    {
        var validator = new Update{{ARG1}}CommandValidation();

        var request = new Update{{ARG1}}Request
        {
            {{ARG1}}Id = new Guid(),
        };

        var result = validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(req => req.RatingValue).WithErrorMessage("RatingValue should be between 1 and 5.");
    }
}