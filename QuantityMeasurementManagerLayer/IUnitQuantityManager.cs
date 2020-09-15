using QuantityMeasurementModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurementManagerLayer
{
    public interface IUnitQuantityManager
    {
        object LengthConvertor(LengthModel unit);
        object TempretureConvertor(TemperetureModel unit);
        object WeightConvertor(WeightModel unit);
        object VolumeConvertor(VolumeModel unit);

    }
}
