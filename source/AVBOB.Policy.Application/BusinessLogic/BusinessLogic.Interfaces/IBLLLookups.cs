using DTO;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBLLLookups
    {
        public Response<List<GenderDTO>> GetGenders();
        public Response<List<PolicyTypeDTO>> GetPolicyTypes();
    }
}
