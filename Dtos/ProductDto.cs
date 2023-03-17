using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntryForm.Dtos
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public IFormFile? Photo { get; set; }
        [Required]
        public double Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }
        [Required]
        public bool IsActive { get; set; }
        

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacurerId { get; set; }

       
    }
}
