using ValidateTheNameModelBinding.DomainPrimitives;

namespace Invariance.Tests;

public class TestFirstName
{
    [Theory]
    [InlineData("Ib")]
    [InlineData("Simon")]
    [InlineData("TwentyCharactersLong")]
    public void Test_that_first_name_right_lenght_passes(string name)
    {
        //Arrange

        //Act
        var exception = Record.Exception(() => new FirstName(name));

        //Assert
        Assert.Null(exception); //Should be null as no exception has been recorded
    }

    [Theory]
    [InlineData("Iben")]
    [InlineData("Simon")]
    [InlineData("Marcus")]
    public void Test_that_first_name_with_right_chars_passes(string name)
    {
        //Arrange

        //Act
        var exception = Record.Exception(() => new FirstName(name));

        //Assert
        Assert.Null(exception); //Should be null as no exception has been recorded
    }

    [Theory]
    [InlineData("I")]
    public void Test_that_first_name_who_are_too_short_fails(string name)
    {
        //Arrange

        //Act
        var exception = Record.Exception(() => new FirstName(name));

        //Assert
        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [InlineData("TwentyOneCharactersLong")]
    public void Test_that_first_name_who_are_too_long_fails(string name)
    {
        //Arrange

        //Act
        var exception = Record.Exception(() => new FirstName(name));

        //Assert
        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory]
    [InlineData("WithNumber67")]
    [InlineData("With¤")]
    [InlineData("With&")]
    [InlineData("With:")]
    public void Test_that_first_name_with_illegal_chars_fails(string name)
    {
        //Arrange

        //Act
        var exception = Record.Exception(() => new FirstName(name));

        //Assert
        Assert.IsType<InvalidDataException>(exception); //Should be null as no exception has been recorded
    }

    [Theory]
    [InlineData(null)]
    public void Test_that_first_name_with_null_fails(string name)
    {
        //Arrange

        //Act
        var exception = Record.Exception(() => new FirstName(name));

        //Assert
        Assert.IsType<ArgumentNullException>(exception); //Should be null as no exception has been recorded
    }
}