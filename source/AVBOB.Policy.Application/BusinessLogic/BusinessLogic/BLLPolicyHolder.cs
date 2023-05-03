using AVBOB.Application.Entities.Context;
using AVBOB.Application.Entities.Models;
using BusinessLogic.Interfaces;
using Communication.Engine;
using DTO;
using DTO.Response;
using Helpers;
using System.Text;

namespace BusinessLogic
{
    public class BLLPolicyHolder : IBLLPolicyHolder
    {
        private readonly AVBOBPolicyApplicationContext _context;

        public BLLPolicyHolder(AVBOBPolicyApplicationContext _context)
        {
            this._context = _context;
        }

        public Response<List<PolicyHolderDTO>> Search(string IDNumber)
        {
            Response<List<PolicyHolderDTO>> response = new Response<List<PolicyHolderDTO>>();
            try
            {
                response.IsSuccess = true;
                response.Data = _context.PolicyHolders.Where(delegate(PolicyHolder x) 
                {
                    return x.Idnumber != null ? Encryption.Decrypt(x.Idnumber, "AVBOB").ToLower().Contains(IDNumber.ToLower()) : false;
                })
                .Select(delegate(PolicyHolder _holder)
                {
                    return new PolicyHolderDTO()
                    {
                        Id = _holder.Id,
                        Idnumber = Encryption.Decrypt(_holder.Idnumber ?? string.Empty, "AVBOB"),
                        Initials = _holder.Initials,
                        Surname = _holder.Surname,
                        DateOfBirth = _holder.DateOfBirth,
                        GenderId = _holder.GenderId,
                        IsActive = _holder.IsActive
                    };
                })
                .ToList();

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public Response<PolicyHolderDTO> Create(PolicyHolderDTO _holder)
        {
            Response<PolicyHolderDTO> response = new Response<PolicyHolderDTO>();
            try
            {
                PolicyHolder holder = new PolicyHolder();

                holder.Idnumber = Encryption.Encrypt(_holder?.Idnumber ?? string.Empty, "AVBOB");
                holder.Initials = _holder?.Initials;
                holder.Surname = _holder?.Surname;
                holder.DateOfBirth = _holder?.DateOfBirth;
                holder.GenderId = _holder?.GenderId;
                holder.IsActive = _holder?.IsActive;

                _context.PolicyHolders.Add(holder);

                _context.SaveChanges();

                if (_holder != null)
                {
                    _holder.Id = holder.Id;
                }

                response.IsSuccess = true;
                response.Data = _holder;


                Email.Send(new Communication.Engine.DTO.EmailDTO()
                {
                    ReplyTo = new string[] { },
                    BCC = new string[] { },
                    CC = new string[] { },
                    IsHTML = true,
                    Message = Encoding.ASCII.GetBytes("Good Day, Please note new policy holder has been created. Kind regards"),
                    EmailAccount = "avbob",
                    Subject = "New Policy Holder",
                    FromName = "AVBOB",
                    From = "no-reply@avbob.co.za",
                    Recipients = new string[] { "support@avbob.co.za" },
                    Attachments = new Communication.Engine.DTO.EmailAttachmentDTO[] { }
                });

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public Response<PolicyHolderDTO> Update(PolicyHolderDTO _holder, int Id)
        {
            Response<PolicyHolderDTO> response = new Response<PolicyHolderDTO>();
            try
            {
                PolicyHolder holder = _context.PolicyHolders.FirstOrDefault(x => x.Id == Id) ?? new PolicyHolder();

                if (holder.Id != 0)
                {
                    holder.Id = _holder.Id;
                    holder.Idnumber = Encryption.Encrypt(_holder?.Idnumber ?? string.Empty, "AVBOB");
                    holder.Initials = _holder?.Initials;
                    holder.Surname = _holder?.Surname;
                    holder.DateOfBirth = _holder?.DateOfBirth;
                    holder.GenderId = _holder?.GenderId;
                    holder.IsActive = _holder?.IsActive;

                    response.IsSuccess = true;
                    response.Data = _holder;

                    _context.SaveChanges();
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Policy holder not found.";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public Response<PolicyHolderDTO> Delete(int Id)
        {
            Response<PolicyHolderDTO> response = new Response<PolicyHolderDTO>();
            try
            {
                PolicyHolder _holder = _context.PolicyHolders.FirstOrDefault(x => x.Id == Id) ?? new PolicyHolder();

                if (_holder.Id != 0)
                {
                    _holder.IsActive = false;
                    response.IsSuccess = true;
                    response.Data = new PolicyHolderDTO()
                    {
                        Id = _holder.Id,
                        Idnumber =  Encryption.Decrypt(_holder?.Idnumber ?? string.Empty, "AVBOB"),
                        Initials = _holder?.Initials,
                        Surname = _holder?.Surname,
                        DateOfBirth = _holder?.DateOfBirth,
                        GenderId = _holder?.GenderId,
                        IsActive = _holder?.IsActive,
                        DateCreated = _holder?.DateCreated,
                    };
                    _context.SaveChanges();
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Policy holder not found.";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }
    }
}
