using EntryForm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntryForm.Dtos
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        
        public string Name { get; set; }
       
        public int Price { get; set; }
        public byte[]? Photo { get; set; }
        
        public bool IsActive { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        public string? Notes { get; set; }
        
        public int CountryId { get; set; }
        
        public int CategoryId { get; set; }
        
        public int ManufacurerId { get; set; }
        public  string CountryName { get; set; }
        public  string CategoryName { get; set; }
        public  string ManufacturerName { get; set; }
    }
}
