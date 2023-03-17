using System.ComponentModel.DataAnnotations;

namespace EntryForm.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
