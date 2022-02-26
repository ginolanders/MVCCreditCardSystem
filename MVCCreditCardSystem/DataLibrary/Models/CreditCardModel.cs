using System;

namespace DataLibrary.Models
{
    public class CreditCardModel
    {
        public string CardNumber { get; set; }
        public int CardCVV { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public string CardCountry { get; set; }
    }
}
