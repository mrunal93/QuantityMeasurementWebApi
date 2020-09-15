using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementManagerLayer;
using QuantityMeasurementModelLayer;

namespace QuantityMeasurementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolumeController : ControllerBase
    {
        public IUnitQuantityManager manager;

        public VolumeController(IUnitQuantityManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult VolumeConvertor(VolumeModel unit)
        {
            var unitResult = manager.VolumeConvertor(unit);

            object result;
            switch (unit.UnitOption)
            {
                case "LITRE_TO_GALLON":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                case "GALLON_TO_LITRE":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));

                    break;
                case "LITER_TO_MILILITRE":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));

                    break;
                case "MILILITER_TO_LITER":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully converted", unitResult));
                    break;
                default:
                    return this.BadRequest();
            }
            return (IActionResult)result;
        }
    }
}
