using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenAI.Models
{
    public class RegitrationModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "User Name")]
        public string? Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Column(TypeName = "boolean")]
        public bool IsAdmin { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string? Email { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Mobile")]
        public int Mobile { get; set; }
    }
}
