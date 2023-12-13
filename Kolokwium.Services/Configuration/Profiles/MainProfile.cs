using AutoMapper;
using Kolokwium.Model;
using Kolokwium.ViewModels.VMs;

namespace Kolokwium.Services.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            //AutoMapper maps
            CreateMap<Car, CarVm>();
            CreateMap<AddOrUpdateCarVm, Car>();

        }
    }
}