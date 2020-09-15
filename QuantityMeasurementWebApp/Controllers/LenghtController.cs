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
    public class LenghtController : ControllerBase
    {
        public IUnitQuantityManager manager;

        public LenghtController(IUnitQuantityManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult LengthConvertor(LengthModel unit)
        {
            var unitResult = manager.LengthConvertor(unit);

            object result;
            switch (unit.UnitOption)
            {
                case "FEET_TO_INCH":
                         result=Ok(new Response(HttpStatusCode.OK, "successfully Converted ", unitResult));
                    break;
                case "INCH_TO_FEET":
                        result=Ok(new Response(HttpStatusCode.OK, "successfully Converted", unitResult));
                    break;
                case "INCH_TO_CENTIMETER":
                        result=Ok(new Response(HttpStatusCode.OK, "successfully Converted", unitResult));
                    break;
                case "CENTIMETER_TO_INCH":
                        result=Ok(new Response(HttpStatusCode.OK, "successfully Converted", unitResult));
                    break;
                case "YARD_TO_FEET":
                        result=Ok(new Response(HttpStatusCode.OK, "successfully Converted", unitResult));
                    break;
                case "FEET_TO_YARD":
                    result= Ok(new Response(HttpStatusCode.OK, "successfully Converted", unitResult));
                    break;
                default:
                    return this.BadRequest();

            }
            return (IActionResult)result;
        }
    }
}
