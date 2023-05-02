using DTO;
using DTO.Response;
using DTO.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBLLPolicy
    {
        public Response<PolicyDTO> Delete(int Id);
        public Response<PolicyDTO> Create(PolicyDTO _holder);
        public Response<PolicyDTO> Update(PolicyDTO _holder, int Id);
        public Response<Search<List<PolicyDTO>>> Search(Search<List<PolicyDTO>> search);


    }
}
