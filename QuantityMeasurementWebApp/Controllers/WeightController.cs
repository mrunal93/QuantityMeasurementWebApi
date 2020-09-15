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
    public class WeightController : ControllerBase
    {
        public IUnitQuantityManager manager;

        public WeightController(IUnitQuantityManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult WeightConvertor(WeightModel unit)
        {
            var unitResult = manager.WeightConvertor(unit);

            object result;
            switch (unit.UnitOption)
            {
                case "KILOGRAM_TO_GRAM":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                case "GRAM_TO_KILOGRAM":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                case "TONNE_TO_KILOGRAM":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                case "KILOGRAM_TO_TONNE":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                default:
                    return this.BadRequest();
            }
            return (IActionResult)result;
        }
    }
}
