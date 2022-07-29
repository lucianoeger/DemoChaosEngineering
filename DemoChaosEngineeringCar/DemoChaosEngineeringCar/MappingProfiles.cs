using AutoMapper;
using DemoChaosEngineeringCar.Model;
using DemoChaosEngineeringCar.ViewModel;

namespace DemoChaosEngineeringCar
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddUpdateCarViewModel, Car>();
        }
    }
}
