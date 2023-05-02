using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVBOB.Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PolicyHolderController : ControllerBase
    {
        private readonly IBLLPolicyHolder _BLLPolicyHolder;

        public PolicyHolderController(IBLLPolicyHolder _BLLPolicyHolder)
        {
            this._BLLPolicyHolder = _BLLPolicyHolder;
        }

        [HttpGet("{IDNumber}")]
        public IActionResult Search(string IDNumber)
        {
            return Ok(_BLLPolicyHolder.Search(IDNumber));
        }

        [HttpPost]
        public IActionResult Create(PolicyHolderDTO holder)
        {
            return Ok(_BLLPolicyHolder.Create(holder));
        }

        [HttpPut("{Id}")]
        public IActionResult Update(PolicyHolderDTO holder, int Id)
        {
            return Ok(_BLLPolicyHolder.Update(holder, Id));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_BLLPolicyHolder.Delete(Id));
        }
    }
}
