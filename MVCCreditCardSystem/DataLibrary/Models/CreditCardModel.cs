using System;

namespace DataLibrary.Models
{
    public class CreditCardModel
    {
        public string cardNumber { get; set; }
        public int cardCVV { get; set; }
        public DateTime cardExpiryDate { get; set; }
        public string cardCountry { get; set; }
    }
}
