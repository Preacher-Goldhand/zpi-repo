using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModels.VMs;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public class CarService : BaseService, ICarService
    {
        public CarService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public CarVm AddOrUpdateCar(AddOrUpdateCarVm addOrUpdateCarVm)
        {
            try {
                if (addOrUpdateCarVm == null)
                    throw new ArgumentNullException("Vm is null");

                var carEntity = Mapper.Map<Car>(addOrUpdateCarVm);

                if (addOrUpdateCarVm.Id.HasValue || addOrUpdateCarVm.Id == 0)
                    DbContext.Cars.Update(carEntity);
                else
                    DbContext.Cars.Add(carEntity);
                
                DbContext.SaveChanges();
                var carVm = Mapper.Map<CarVm>(carEntity);
                return carVm;

            }catch (Exception ex) {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public CarVm GetCar(Expression<Func<Car, bool>> filterExpression)
        {
            try {
                if (filterExpression == null)
                    throw new ArgumentException("parameter is null");

                var carEntity = DbContext.Cars.FirstOrDefault(filterExpression);
                var carVm = Mapper.Map<CarVm>(carEntity);
                return carVm;

            }catch (Exception ex) {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

       public IEnumerable<CarVm> GetCars(Expression<Func<Car, bool>>? filterExpression = null)
       {
            try
            {
                var carsQuery = DbContext.Cars.AsQueryable();

                if (filterExpression != null)
                {
                    carsQuery = carsQuery.Where(filterExpression);
                }

                var carVms = Mapper.Map<IEnumerable<CarVm>>(carsQuery);
                return carVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
       }

        public void DeleteCar(int id)
        {
            try {
                var carEntity = DbContext.Cars.FirstOrDefault(x => x.Id == id);

                if (carEntity == null)
                {
                    throw new ArgumentException("parameter is null");
                }
                else {
                    DbContext.Cars.Remove(carEntity);
                }    
                DbContext.SaveChanges();
                
            }catch (Exception ex) {
                Logger.LogError(ex, ex.Message);
                throw;
            }   
        }
    }
}