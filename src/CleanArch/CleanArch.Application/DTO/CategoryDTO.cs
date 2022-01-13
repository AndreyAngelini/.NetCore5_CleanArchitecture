using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MaxLength(100)]
        [MinLength(3)]
        [DisplayName("Name")]
        public string Name { get; set; }

    }
}
