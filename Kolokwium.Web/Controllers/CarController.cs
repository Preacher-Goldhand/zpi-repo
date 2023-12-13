using AutoMapper;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModels.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Web.Controllers
{
    [Route("/api/Car")]
    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        public CarController(ILogger logger, IMapper mapper, ICarService carService) : base(logger, mapper)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try {
                var cars = _carService.GetCars();
                return Ok(cars);

            }catch(Exception e) 
            {
                Logger.LogError(e, e.Message);
                return StatusCode(500, "Error occured");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try {
                var car = _carService.GetCar(c => c.Id == id);
                return Ok(car);

            }catch(Exception e)
            {
                Logger.LogError(e, e.Message);
                return StatusCode(500, "Error occured");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateCarVm addOrUpdateCarVm)
        {
            return PostOrPutHelper(addOrUpdateCarVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateCarVm addOrUpdateCarVm)
        {
            return PostOrPutHelper(addOrUpdateCarVm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                _carService.DeleteCar(id);
                return Ok();
            }catch(Exception e)
            {
                Logger.LogError(e, e.Message);
                return StatusCode(500, "Error occured");
            }
        }

        private IActionResult PostOrPutHelper(AddOrUpdateCarVm addOrUpdateCarVm)
        {
            try {   
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(_carService.AddOrUpdateCar(addOrUpdateCarVm));
            }catch(Exception e)
            {
                Logger.LogError(e, e.Message);
                return StatusCode(500, "Error occured");
            }
        }
    }
}