using MaskWebApi.Models;
using MaskWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaskWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MaskService _maskService;
        public ValuesController(MaskService maskService) { 
            _maskService = maskService;
        }

        [HttpGet]
        public IActionResult StringManipulation(string strVal) 
        {
            var returnString = _maskService.StringManipulation(strVal);


            return Ok(returnString);        
        }


        [HttpGet]
        public IActionResult RegularExpressions(string strVal)
        {
            var returnString = _maskService.RegularExpressions(strVal);

            return Ok(returnString);
        }

        [HttpPost]
        public IActionResult MaskingJSONSerializer(Person strVal)
        {
            var returnString = _maskService.MaskingJSONSerializer(strVal);

            return Ok(returnString);
        }


        [HttpPost]
        public IActionResult MaskingSensitiveData(Customer strVal)
        {
            var returnString = _maskService.MaskObjectProperties(strVal);

            return Ok(returnString);
        }


        [HttpGet]
        public IActionResult ProtectionProvider(string strVal)
        {
            var returnString = _maskService.ProtectionProvider(strVal);

            return Ok(returnString);
        }

    }
}
