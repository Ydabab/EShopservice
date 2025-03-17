using EShop.Appliication;

namespace EShop.Application.Tests;
public class CreditCardServiceTest
{
    [Theory]
    [InlineData("3497 7965 8312 797")]
    [InlineData("345-470-784-783-010")]
    [InlineData("4532289052809181")]
    public void ValidateCard_CorrectNumber_ReturnTrue(string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        var result = card.ValidateCard(cardNumber);

        // Assert
        Assert.True(result);
    }
    [Theory]
    [InlineData("1234")]
    [InlineData("123456789012345678901234567890")]
    [InlineData("1234*&&ujd71947128&*())**@")]
    public void ValidateCard_WrongNumber_ReturnFalse(string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        var result = card.ValidateCard(cardNumber);

        // Assert
        Assert.False(result);
    }
    [Theory]
    [InlineData ("American Express", "3497 7965 8312 797")]
    [InlineData ("Visa", "4024-0071-6540-1778")]
    [InlineData("MasterCard", "5530016454538418")]
    public void GetCardType_CorrectCardType_ReturnTrue(string cardType, string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        var result = card.GetCardType(cardNumber);
        // Assert
        Assert.Equal(cardType, result);
    }
    [Theory]
    [InlineData("American Express", "4024-0071-6540-1778")]
    [InlineData("Visa", "5530016454538418")]
    [InlineData("MasterCard", "3497 7965 8312 797")]
    public void GetCardType_WrongCardType_ReturnFalse(string cardType, string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        var result = card.GetCardType(cardNumber);
        // Assert
        Assert.NotEqual(cardType, result);
    }
}