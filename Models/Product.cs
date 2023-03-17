using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EntryForm.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public byte[]? Photo { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreationDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacurerId { get; set; }
        public  Country Country { get; set; }
        public  Category Category { get; set; }
        public  Manufacturer Manufacturer { get; set; }

        public Product()
        {
            CreationDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}

