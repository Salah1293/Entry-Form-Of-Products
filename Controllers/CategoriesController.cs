using AutoMapper;
using EntryForm.Dtos;
using EntryForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntryForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _unitOfWork.Category.GetAll();
            
            return Ok(data);

        }


    }
}
