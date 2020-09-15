using QuantityMeasurementModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurementRepositoryLayer
{
    public interface IUnitQuantityRepository
    {
        object WeightConvertor(WeightModel unit);
        object LengthConvertor(LengthModel unit);
        object TempretureConvertor(TemperetureModel unit);
        object VolumeConvertor(VolumeModel unit);
    }
}
