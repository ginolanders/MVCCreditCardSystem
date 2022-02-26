using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCreditCardSystem.Models
{
    public class CreditCardModel
    {
        // (CreditCardAttribute) CreditCardType.All = VISA, AMEX, MasterCard or Discover
        [CreditCard(AcceptedCardTypes = CreditCardAttribute.CreditCardType.All)]
        [Required(ErrorMessage = "You need to supply a valid credit card number.")]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }


        [Display(Name = "CVV")]
        [Required(ErrorMessage = "You need to supply the CVV number.")]
        public int CardCVV { get; set; }


        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You need to supply the expiry date.")]
        public DateTime CardExpiryDate { get; set; }


        [Display(Name = "Country")]
        [Required(ErrorMessage = "You need to supply the country.")]
        public string CardCountry { get; set; }
    }
}