using System.ComponentModel.DataAnnotations;

namespace EntryForm.Models
{
    public class Manufacturer
    {

        public int ManufacturerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
