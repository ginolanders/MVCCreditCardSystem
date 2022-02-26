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

    //Credit Card Types
    public enum CreditCardType
    {
        VISA = 1,
        MasterCard = 2,
        AMEX = 3,
        Discover = 4,

        All = CreditCardType.VISA | CreditCardType.MasterCard | CreditCardType.AMEX | CreditCardType.Discover,
    }

    //Determine if the card number submitted is allowed based on the credit card providers
    private bool IsValidType(string cardNum, CreditCardType creditCardType)
    {
        // Visa
        if (Regex.IsMatch(cardNum, "^(4)") && ((creditCardType & CreditCardType.VISA) != 0))
        {
            return cardNum.Length == 13 || cardNum.Length == 16;
        }

        // MasterCard
        if (Regex.IsMatch(cardNum, "^(51|52|53|54|55)") && ((creditCardType & CreditCardType.MasterCard) != 0))
        {
            return cardNum.Length == 16;
        }

        // AMEX
        if (Regex.IsMatch(cardNum, "^(34|37)") && ((creditCardType & CreditCardType.AMEX) != 0))
        {
            return cardNum.Length == 15;
        }

        // Discover
        if (Regex.IsMatch(cardNum, "^(6011|65)") && ((creditCardType & CreditCardType.Discover) != 0))
        {
            return cardNum.Length == 16;
        }

        return false;
    }

    /*
     * Luhn Algorithm
     * --------------
     * Calculate sum with a pattern of 2,1,2,1,2...
     * Multiple digit by 2
     * Example: 
     * Card:    5|1|0|7|4|3|7|3|7|8|7|1|4|8|4|9
     * Pattern: 2|1|2|1|2|1|2|1|2|1|2|1|2|1|2|1
     * Total:   1|1|0|7|8|3|5|3|5|8|5|1|8|8|8|9
     * Add up the result mod by 10 - if the result end in zero, then the credit number is value
     */
    private bool IsValidNumber(string cardNum)
    {
        //Take card number input and place it into an int array
        int[] cardArray = new int[cardNum.Length];

        for (int i = 0; i < cardNum.Length; i++)
        {
            /*
             * Each ASCII character is represented by values from 0 through 127.
             * To get the integer equivalent of characters 0 to 9, simply subtract 0 from it.
             */
            cardArray[i] = cardNum[i] - '0';
        }

        //Double the value for every other digit from right to left
        for (int i = cardArray.Length - 2; i >= 0; i -= 2)
        {
            int tempCardNum = cardArray[i];
            tempCardNum *= 2;

            if (tempCardNum > 9)
            {
                tempCardNum = (tempCardNum % 10) + 1;
            }

            cardArray[i] = tempCardNum;
        }

        //Calculate total of card value
        int cardTotal = 0;
        for (int i = 0; i < cardArray.Length; i++)
        {
            cardTotal += cardArray[i];
        }

        //If no remainder, then it is a valid number
        return cardTotal % 10 == 0;
    }
}