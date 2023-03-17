using EntryForm.Dtos;
using EntryForm.Interfaces;
using EntryForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EntryForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductsController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private new List<string> _allowedExtentions = new List<string> { ".jpg", ".png" };

        private long _MaxAllowedPhotoSize = 20000000;


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetById(id);

            if (product == null)
                return NotFound($"No product was found with Id :{id}");

            var data = _mapper.Map<ProductDetailsDto>(product);

            return Ok(data);
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAll();

            var data = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return Ok(data);
                
        }



        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] ProductDto dto)
        {

            var product = _mapper.Map<Product>(dto);

            if (dto.Photo != null)
            { 

                if (!_allowedExtentions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
                    return BadRequest("only .jpg and .png images are allowed!");


                if (dto.Photo.Length > _MaxAllowedPhotoSize)
                    return BadRequest("only allowed photo size is below 20MB");


                using var dataStream = new MemoryStream();

                await dto.Photo.CopyToAsync(dataStream);

                product.Photo = dataStream.ToArray();

            }
            
           
            product.CreationDate= DateTime.Now;

            await _unitOfWork.Products.Add(product);

            _unitOfWork.Complete();

            return Ok(product);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ProductDto dto)
        {
            var product = await _unitOfWork.Products.GetById(id);
            

            if (product == null)
                return NotFound($"No product was found with Id :{id}");

            if (dto.Photo != null)
            {

            

                if (!_allowedExtentions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
                    return BadRequest("only .jpg and .png images are allowed!");


                if (dto.Photo.Length > _MaxAllowedPhotoSize)
                    return BadRequest("only allowed photo size is below 20MB");

                using var dataStream = new MemoryStream();

                dto.Photo.CopyToAsync(dataStream);


                product.Photo = dataStream.ToArray();

            }



            product.Name = dto.Name;
            product.CategoryId = dto.CategoryId;
            product.CountryId = dto.CountryId;
            product.ManufacurerId = dto.ManufacurerId;
            
            product.ModifiedDate = DateTime.Now;

            _unitOfWork.Products.Update(product);
            _unitOfWork.Complete();
            return Ok(product);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
        var product = await _unitOfWork.Products.GetById(id);

            if (product == null)
                return NotFound($"No product was found with Id :{id}");

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();
            
            return Ok();

        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync(string productName,
            string manufacturerName, string categoryName )
        {
            var products = await _unitOfWork.Products.Search(productName, manufacturerName, categoryName);

            var data = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return Ok(data);
        }




    }
}
