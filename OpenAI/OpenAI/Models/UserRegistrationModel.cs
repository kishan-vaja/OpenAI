using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OpenAI.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "User Name")]
        public string? Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [NotMapped]
        [DisplayName("Confirm Password")]
        [Display(Name = "Password")]
        public string? ConfirmPassword { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAdmin { get; set; }
    }
}
