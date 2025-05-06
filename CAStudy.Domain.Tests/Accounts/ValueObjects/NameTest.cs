using CAStudy.Domain.Accounts.ValueObjects;

namespace CAStudy.Domain.Tests.Accounts.ValueObjects;

public class NameTest
{
    [Fact]
    public void ShouldOverrideToString()
    {
        // Arrange
        var name =  Name.Create("John Doe");

        // Act
        var result = name.ToString();

        // Assert
        Assert.Equal("John Doe", result);
    }
    [Fact]
    public void ShouldImplicitConvertToString()
    {
        var name =  Name.Create("John Doe");
        string data = name;
    }
    
    [Fact]
    public void ShouldCreateName()
    {
        // Arrange
        var name = "John";

    }
    
    [Fact]
    public void ShouldFailIfFirstNameLengthIsNotValid()
    {
        Assert.Throws<Exception>(() =>
        {
            var name = Name.Create("Luis Unzueta");
        });
    }
}