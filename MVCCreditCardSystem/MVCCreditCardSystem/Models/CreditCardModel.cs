using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCreditCardSystem.Models
{
    public class CreditCardModel
    {
        [CreditCard(AcceptedCardTypes = CreditCardAttribute.CreditCardType.All)]
        [Required(ErrorMessage = "You need to supply a valid credit card number.")]
        [Display(Name = "Card Number")]
        public string cardNumber { get; set; }


        [Display(Name = "CVV")]
        [Required(ErrorMessage = "You need to supply the CVV number.")]
        public int cardCVV { get; set; }


        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You need to supply the expiry date.")]
        public DateTime cardExpiryDate { get; set; }


        [Display(Name = "Country")]
        [Required(ErrorMessage = "You need to supply the country.")]
        public string cardCountry { get; set; }
    }
}