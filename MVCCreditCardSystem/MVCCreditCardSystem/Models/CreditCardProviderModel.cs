using System.ComponentModel.DataAnnotations;

namespace MVCCreditCardSystem.Models
{
    public class CreditCardProviderModel
    {
        [Display(Name = "Provider Name")]
        public string ProviderName { get; set; }
    }
}