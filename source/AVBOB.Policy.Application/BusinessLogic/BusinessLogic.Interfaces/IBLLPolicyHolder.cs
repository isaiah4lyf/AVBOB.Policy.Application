using DTO;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBLLPolicyHolder
    {
        public Response<PolicyHolderDTO> Delete(int Id);
        public Response<List<PolicyHolderDTO>> Search(string IDNumber);
        public Response<PolicyHolderDTO> Create(PolicyHolderDTO _holder);
        public Response<PolicyHolderDTO> Update(PolicyHolderDTO _holder, int Id);
        
    }
}
