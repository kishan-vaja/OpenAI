using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenAI.Models
{
    public class GenAIToolsModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("GenAi Name")]
        public string GenAIName { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        [DisplayName("Summary")]
        public string? Summary { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image File")]
        public string? ImageFilename { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile? ImageFile { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Anchor Link")]
        public string? AnchorLink { get; set; }

        [Column(TypeName = "int")]
        [DisplayName("Likes")]
        public int? Like { get; set; }
    }
}
