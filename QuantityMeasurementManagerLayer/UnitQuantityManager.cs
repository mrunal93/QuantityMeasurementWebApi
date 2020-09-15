using QuantityMeasurementModelLayer;
using QuantityMeasurementRepositoryLayer;
using System;

namespace QuantityMeasurementManagerLayer
{
    public class UnitQuantityManager : IUnitQuantityManager
    {
        public readonly IUnitQuantityRepository unitRepository;
        public UnitQuantityManager(IUnitQuantityRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }
        public object LengthConvertor(LengthModel unit)
        {
            return unitRepository.LengthConvertor(unit);            
        }
        public object TempretureConvertor(TemperetureModel unit)
        {
            return unitRepository.TempretureConvertor(unit);
        }
        public object WeightConvertor(WeightModel unit)
        {
            return unitRepository.WeightConvertor(unit);
        }


        public object VolumeConvertor(VolumeModel unit)
        {
            return unitRepository.VolumeConvertor(unit);
        }
    }
}
