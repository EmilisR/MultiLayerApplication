using System.ComponentModel.DataAnnotations;

namespace LibraryLayer
{
    public class Enums
    {
        public enum PaymentType
        {
            Cash,
            CreditCard
        }
        
        public enum ProductCategory
        {
            [Display(Name = "Televizoriai")]
            TV = 1,
            [Display(Name = "Kompiuteriai")]
            Computers,
            [Display(Name = "Multimedija")]
            Media,
            [Display(Name = "Žaidimai")]
            Games,
            [Display(Name = "Telefonai")]
            Phones
        }

        public enum Currency
        {
            EUR,
            USD,
            GBP
        }

        public enum QuantitySource
        {
            Sandelyje,
            Atvykstantys
        }
    }
}
