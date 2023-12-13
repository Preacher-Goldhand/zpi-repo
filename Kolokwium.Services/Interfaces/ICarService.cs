using System.Linq.Expressions;
using Kolokwium.Model;
using Kolokwium.ViewModels.VMs;

namespace Kolokwium.Services.Interfaces
{
    public interface ICarService
    {
        CarVm AddOrUpdateCar(AddOrUpdateCarVm addOrUpdateCarVm);
        CarVm GetCar(Expression<Func<Car, bool>> filterExpression);
        IEnumerable<CarVm> GetCars(Expression<Func<Car, bool>> ? filterExpression = null);
        void DeleteCar(int id);
    }
}