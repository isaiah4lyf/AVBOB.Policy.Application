using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVBOB.Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IBLLLookups _BLLLookup;

        public LookupController(IBLLLookups _BLLLookup)
        {
            this._BLLLookup = _BLLLookup;
        }


        [HttpGet]
        public IActionResult GetGenders()
        {
            return Ok(_BLLLookup.GetGenders());
        }

        [HttpGet]
        public IActionResult GetPolicyTypes()
        {
            return Ok(_BLLLookup.GetPolicyTypes());
        }
    }
}
