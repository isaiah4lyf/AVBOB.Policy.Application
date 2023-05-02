using AVBOB.Application.Entities.Context;
using AVBOB.Application.Entities.Models;
using BusinessLogic.Interfaces;
using DTO;
using DTO.Response;
using DTO.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLLPolicy : IBLLPolicy
    {
        private readonly AVBOBPolicyApplicationContext _context;

        public BLLPolicy(AVBOBPolicyApplicationContext _context)
        {
            this._context = _context;
        }

        public Response<Search<List<PolicyDTO>>> Search(Search<List<PolicyDTO>> search)
        {
            Response<Search<List<PolicyDTO>>> response = new Response<Search<List<PolicyDTO>>>();
            try
            {
                var query = _context.Policies.Select(x => new PolicyDTO()
                {
                    Id = x.Id,
                    PolicyNumber = x.PolicyNumber,
                    PolicyTypeId = x.PolicyTypeId,
                    PolicyHolderId = x.PolicyHolderId,
                    CommencementDate = x.CommencementDate,
                    Installment = x.Installment,
                    ApplicationFormDocumentId = x.ApplicationFormDocumentId,
                    IsActive = x.IsActive,
                    DateCreated = DateTime.Now,
                    PolicyType = new PolicyTypeDTO()
                    {
                        Id = x.PolicyType.Id,
                        Description = x.PolicyType.Description,
                    },
                    ApplicationFormDocument = new DocumentDTO()
                    {
                        Id = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Id : 0,
                        Description = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Description : string.Empty,
                        DocumentTypeId = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.DocumentTypeId : 0,
                        Title = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Title : string.Empty,
                        OriginalTitle = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.OriginalTitle : string.Empty,
                        Name = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Name : string.Empty,
                        Extension = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Extension : string.Empty,
                        Size = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Size : string.Empty,
                        DateModified = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.DateModified : DateTime.Now,
                        Url = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.Url : string.Empty,
                        IOrder = x.ApplicationFormDocument != null ? x.ApplicationFormDocument.IOrder : 0

                    }
                }).Where(x => x.PolicyHolderId == search.Id && (x.IsActive.HasValue ? x.IsActive.Value : false)).OrderByDescending(x => x.DateCreated);

                search.Count = query.Count();
                search.Results = query.Skip(search.PageIndex * search.PageSize).Take(search.PageSize).ToList();

                response.IsSuccess = true;
                response.Data = search;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public Response<PolicyDTO> Create(PolicyDTO _holder)
        {
            Response<PolicyDTO> response = new Response<PolicyDTO>();
            try
            {
                Document document = _context.Documents.FirstOrDefault(x => x.Id == _holder.ApplicationFormDocument.Id) ?? new Document();
                document.Description = _holder.ApplicationFormDocument.Description;
                document.DocumentTypeId = _holder.ApplicationFormDocument.DocumentTypeId;
                document.Title = _holder.ApplicationFormDocument.Title;
                document.OriginalTitle = _holder.ApplicationFormDocument.OriginalTitle;
                document.Name = _holder.ApplicationFormDocument.Name;
                document.Extension = _holder.ApplicationFormDocument.Extension;
                document.Size = _holder.ApplicationFormDocument.Size;
                document.DateModified = _holder.ApplicationFormDocument.DateModified;
                document.Url = _holder.ApplicationFormDocument.Url;
                document.IOrder = _holder.ApplicationFormDocument.IOrder;
                if (document.Id == 0)
                {
                    document.Guid = Guid.NewGuid();
                    document.IsActive = true;
                    document.DateCreated = DateTime.Now;

                    _context.Documents.Add(document);
                    _context.SaveChanges();
                }
                else
                {
                    _context.SaveChanges();
                }

                Policy holder = new Policy();

                holder.PolicyNumber = _holder?.PolicyNumber;
                holder.PolicyTypeId = _holder.PolicyTypeId;
                holder.PolicyHolderId = _holder.PolicyHolderId;
                holder.CommencementDate = _holder.CommencementDate;
                holder.Installment = _holder?.Installment;
                holder.ApplicationFormDocumentId = document.Id;
                holder.IsActive = _holder?.IsActive;
                holder.DateCreated = DateTime.Now;

                _context.Policies.Add(holder);

                _context.SaveChanges();

                if (_holder != null)
                {
                    _holder.Id = holder.Id;
                }

                response.IsSuccess = true;
                response.Data = _holder;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public Response<PolicyDTO> Update(PolicyDTO _holder, int Id)
        {
            Response<PolicyDTO> response = new Response<PolicyDTO>();
            try
            {
                Policy holder = _context.Policies.FirstOrDefault(x => x.Id == Id) ?? new Policy();

                if (holder.Id != 0)
                {
                    Document document = _context.Documents.FirstOrDefault(x => x.Id == _holder.Id) ?? new Document();
                    document.Description = _holder.ApplicationFormDocument.Description;
                    document.DocumentTypeId = _holder.ApplicationFormDocument.DocumentTypeId;
                    document.Title = _holder.ApplicationFormDocument.Title;
                    document.OriginalTitle = _holder.ApplicationFormDocument.OriginalTitle;
                    document.Name = _holder.ApplicationFormDocument.Name;
                    document.Extension = _holder.ApplicationFormDocument.Extension;
                    document.Size = _holder.ApplicationFormDocument.Size;
                    document.DateModified = _holder.ApplicationFormDocument.DateModified;
                    document.Url = _holder.ApplicationFormDocument.Url;
                    document.IOrder = _holder.ApplicationFormDocument.IOrder;
                    if (document.Id == 0)
                    {
                        document.Guid = Guid.NewGuid();
                        document.IsActive = true;
                        document.DateCreated = DateTime.Now;

                        _context.Documents.Add(document);
                        _context.SaveChanges();
                    }
                    else
                    {
                        _context.SaveChanges();
                    }

                    holder.PolicyNumber = _holder?.PolicyNumber;
                    holder.PolicyTypeId = _holder.PolicyTypeId;
                    holder.PolicyHolderId = _holder.PolicyHolderId;
                    holder.CommencementDate = _holder.CommencementDate;
                    holder.Installment = _holder?.Installment;
                    holder.ApplicationFormDocumentId = document.Id;
                    holder.IsActive = _holder?.IsActive;
                    holder.DateCreated = DateTime.Now;

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

        public Response<PolicyDTO> Delete(int Id)
        {
            Response<PolicyDTO> response = new Response<PolicyDTO>();
            try
            {
                Policy _holder = _context.Policies.FirstOrDefault(x => x.Id == Id) ?? new Policy();

                if (_holder.Id != 0)
                {
                    _holder.IsActive = false;
                    response.IsSuccess = true;
                    response.Data = new PolicyDTO()
                    {
                        PolicyNumber = _holder?.PolicyNumber,
                        PolicyTypeId = _holder.PolicyTypeId,
                        PolicyHolderId = _holder.PolicyHolderId,
                        CommencementDate = _holder.CommencementDate,
                        Installment = _holder?.Installment,
                        ApplicationFormDocumentId = _holder?.ApplicationFormDocumentId,
                        IsActive = _holder?.IsActive,
                        DateCreated = DateTime.Now

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
