using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CreditCardAttribute : ValidationAttribute
{
    private CreditCardType cardTypes;
    public CreditCardType AcceptedCardTypes
    {
        get => cardTypes;
        set => cardTypes = value;
    }

    public CreditCardAttribute() => cardTypes = CreditCardType.All;

    public CreditCardAttribute(CreditCardType AcceptedCardTypes) => cardTypes = AcceptedCardTypes;

    public override bool IsValid(object value)
    {
        var cardNum = Convert.ToString(value);

        return string.IsNullOrWhiteSpace(cardNum) ? true : IsValidType(cardNum, cardTypes) && IsValidNumber(cardNum);
    }

    public enum CreditCardType
    {
        VISA = 0,
        MasterCard = 1,
        AMEX = 2,
        Discover = 3,

        All = CreditCardType.VISA | CreditCardType.MasterCard | CreditCardType.AMEX | CreditCardType.Discover,
    }

    private bool IsValidType(string cardNumber, CreditCardType cardType)
    {
        // Visa
        if (Regex.IsMatch(cardNumber, "^(4)") && ((cardType & CreditCardType.VISA) != 0))
            return cardNumber.Length == 13 || cardNumber.Length == 16;

        // MasterCard
        if (Regex.IsMatch(cardNumber, "^(51|52|53|54|55)") && ((cardType & CreditCardType.MasterCard) != 0))
            return cardNumber.Length == 16;

        // AMEX
        if (Regex.IsMatch(cardNumber, "^(34|37)") && ((cardType & CreditCardType.AMEX) != 0))
            return cardNumber.Length == 15;

        // Discover
        if (Regex.IsMatch(cardNumber, "^(6011|65)") && ((cardType & CreditCardType.Discover) != 0))
            return cardNumber.Length == 16;

        return false;
    }

    private bool IsValidNumber(string number)
     {
        int[] DELTAS = new int[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
        int checksum = 0;
        char[] chars = number.ToCharArray();
        for (int i = chars.Length - 1; i > -1; i--)
        {
            int j = ((int)chars[i]) - 48;
            checksum += j;
            if ((i - chars.Length) % 2 == 0)
                checksum += DELTAS[j];
        }

        return checksum % 10 == 0;
    }
}