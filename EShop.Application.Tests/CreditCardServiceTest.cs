using EShop.Appliication;
using EShop.Domain.Exceptions.CardNumber;

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
    [InlineData("5352 3000")]

    public void ValidateCard_TooShortNumber_ReturnNumberTooShortException(string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        // Assert
        Assert.Throws<CardNumberTooShortException>(()=> card.ValidateCard(cardNumber));
    }
    [Theory]
    [InlineData("123456789012345678901234567890")]
    [InlineData("3000 3000 3000 8200 8200 8200")]
    public void ValidateCard_TooLongNumber_ReturnNumberTooLongException(string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        // Assert
        Assert.Throws<CardNumberTooLongException>(() => card.ValidateCard(cardNumber));
    }
    [Theory]
    [InlineData("1234*&&ujd7194712")]
    [InlineData("111133333*&&&&$*#")]
    public void ValidateCard_InvalidNumber_ReturnNumberInvalidException(string cardNumber)
    {
        // Arrange
        var card = new CreditCardService();
        // Act
        // Assert
        Assert.Throws<CardNumberInvalidException>(()=> card.ValidateCard(cardNumber));
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