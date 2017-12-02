using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLayer
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        public string MobileNumber { get; set; }
        [Required]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
