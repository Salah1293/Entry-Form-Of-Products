using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntryForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufaturersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ManufaturersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }




        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _unitOfWork.Manufacturer.GetAll();

            return Ok(data);

        }


    }
}
