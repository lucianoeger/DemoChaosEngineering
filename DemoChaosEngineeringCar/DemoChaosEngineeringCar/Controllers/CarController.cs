using AutoMapper;
using DemoChaosEngineeringCar.Model;
using DemoChaosEngineeringCar.Repository;
using DemoChaosEngineeringCar.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoChaosEngineeringCar.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly CarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(ILogger<CarController> logger, CarRepository carRepository, IMapper mapper)
        {
            _logger = logger;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public List<Car> Get()
            => _carRepository.Get();

        [HttpGet("{id}")]
        public async Task<Car> GetById(int id)
           => await _carRepository.GetByIdAsync(id);

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateCarViewModel model)
        {
            await _carRepository.AddAsync(_mapper.Map<Car>(model));
            return Ok(new { message = "Car created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddUpdateCarViewModel model)
        {
            await _carRepository.UpdateAsync(id, _mapper.Map<Car>(model));
            return Ok(new { message = "Car updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carRepository.DeleteAsync(id);
            return Ok(new { message = "Car deleted" });
        }
    }
}