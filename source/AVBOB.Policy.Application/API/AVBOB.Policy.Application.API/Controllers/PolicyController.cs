using BusinessLogic.Interfaces;
using DTO;
using DTO.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVBOB.Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IBLLPolicy _BLLPolicy;

        public PolicyController(IBLLPolicy _BLLPolicy)
        {
            this._BLLPolicy = _BLLPolicy;
        }

        [HttpPost]
        public IActionResult Search(Search<List<PolicyDTO>> search)
        {
            return Ok(_BLLPolicy.Search(search));
        }

        [HttpPost]
        public IActionResult Create(PolicyDTO holder)
        {
            return Ok(_BLLPolicy.Create(holder));
        }

        [HttpPut("{Id}")]
        public IActionResult Update(PolicyDTO holder, int Id)
        {
            return Ok(_BLLPolicy.Update(holder, Id));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_BLLPolicy.Delete(Id));
        }
    }
}
