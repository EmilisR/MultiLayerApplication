using System.ComponentModel.DataAnnotations;

namespace GuiLayer.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public string Error { get; set; }
    }
}