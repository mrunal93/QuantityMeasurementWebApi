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
    public class TempretureController1 : ControllerBase
    {
        public IUnitQuantityManager manager;

        public TempretureController1(IUnitQuantityManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult TempretureConvertor(TemperetureModel unit)
        {
            var unitResult = manager.TempretureConvertor(unit);

            object result;
            switch (unit.UnitOption)
            {
                case "FAHRENHIET_TO_CELCIUS":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                case "CELCIUS_TO_FAHRENHIET":
                    result = Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));

                    break;

                default:
                    return this.BadRequest();
            }
            return (IActionResult)result;
        }
    }
}
