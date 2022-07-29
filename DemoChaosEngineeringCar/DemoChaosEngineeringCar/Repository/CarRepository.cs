using DemoChaosEngineeringCar.Database;
using DemoChaosEngineeringCar.Model;

namespace DemoChaosEngineeringCar.Repository
{
    public class CarRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CarRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Car> Get()
            => _databaseContext.Cars.ToList();

        public async Task<Car> GetByIdAsync(int id)
            => await _databaseContext.Cars.FindAsync(id);

        public async Task AddAsync(Car car)
        {
            await _databaseContext.Cars.AddAsync(car);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Car updateCar)
        {
            var carDb = _databaseContext.Cars.Find(id);
            if (carDb != null)
            {
                carDb.SetName(updateCar.Name);
                carDb.SetPrice(updateCar.Price);
                carDb.SetYear(updateCar.Year);
                _databaseContext.Cars.Update(carDb);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var car = _databaseContext.Cars.Find(id);
            if (car != null)
            {
                _databaseContext.Cars.Remove(car);
                await _databaseContext.SaveChangesAsync();
            }
        }
    }
}
