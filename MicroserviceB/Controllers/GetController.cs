using MicroserviceB.Services;
using MicroserviceB.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroserviceB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase 
    {
        private IApiResponseService _getResponseService;
        public GetController(IApiResponseService getResponseService)
        {
            _getResponseService = getResponseService;
        }

        // GET: api/<GetController>
        [HttpGet]
        public IActionResult Get()
        {
            // Get Data from MicroserviceA

            var response =  _getResponseService.GetResponse("weatherforecast");
            //var data = ConvertResponseHelper.GetResponseData<>(response);

            return Ok(response.Result.Content);
        }



    }
}
