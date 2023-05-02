using AVBOB.Application.Entities.Context;
using BusinessLogic.Interfaces;
using DTO;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLLLookups : IBLLLookups
    {
        private readonly AVBOBPolicyApplicationContext _context;

        public BLLLookups(AVBOBPolicyApplicationContext _context)
        {
            this._context = _context;
        }

        public Response<List<GenderDTO>> GetGenders()
        {
            Response<List<GenderDTO>> response = new Response<List<GenderDTO>>();
            try
            {
                response.IsSuccess = true;
                response.Data = _context.Genders.Where(x => x.IsActive.HasValue ? x.IsActive.Value : false).Select(g => new GenderDTO()
                {
                    Id = g.Id,
                    Description = g.Description,
                }).ToList();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<PolicyTypeDTO>> GetPolicyTypes()
        {
            Response<List<PolicyTypeDTO>> response = new Response<List<PolicyTypeDTO>>();
            try
            {
                response.IsSuccess = true;
                response.Data = _context.PolicyTypes.Where(x => x.IsActive.HasValue ? x.IsActive.Value : false).Select(g => new PolicyTypeDTO()
                {
                    Id = g.Id,
                    Description = g.Description,
                }).ToList();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
