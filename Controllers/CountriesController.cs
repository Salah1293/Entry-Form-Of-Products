using AutoMapper;
using EntryForm.Interfaces;
using EntryForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntryForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }




        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _unitOfWork.Country.GetAll();

            return Ok(data);

        }


    }
}

