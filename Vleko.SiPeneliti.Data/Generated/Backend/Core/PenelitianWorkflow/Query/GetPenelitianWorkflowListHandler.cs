//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Vleko.SiPeneliti.Data;
using Vleko.SiPeneliti.Data.Model;
using Vleko.Result;
using Vleko.SiPeneliti.Core.Response;
using Vleko.SiPeneliti.Core.Helper;

namespace Vleko.SiPeneliti.Core.PenelitianWorkflow.Query
{
    public class GetPenelitianWorkflowListRequest : ListRequest,IListRequest<GetPenelitianWorkflowListRequest>,IRequest<ListResponse<PenelitianWorkflowResponse>>
    {
    }
    internal class GetPenelitianWorkflowListHandler : IRequestHandler<GetPenelitianWorkflowListRequest, ListResponse<PenelitianWorkflowResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPenelitianWorkflowListHandler(
            ILogger<GetPenelitianWorkflowListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<PenelitianWorkflowResponse>> Handle(GetPenelitianWorkflowListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<PenelitianWorkflowResponse> result = new ListResponse<PenelitianWorkflowResponse>();
            try
            {
				var query = _context.Entity<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow>().AsQueryable();

				#region Filter
				Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, object>> column_sort = null;
				List<Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, bool>>> where = new List<Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, bool>>>();
				if (request.Filter != null && request.Filter.Count > 0)
				{
					foreach (var f in request.Filter)
					{
						var obj = ListExpression(f.Search, f.Field, true);
						if (obj.where != null)
							where.Add(obj.where);
					}
				}
				if (where != null && where.Count() > 0)
				{
					foreach (var w in where)
					{
						query = query.Where(w);
					}
				}
				if (request.Sort != null)
                {
					column_sort = ListExpression(request.Sort.Field, request.Sort.Field, false).order!;
					if(column_sort != null)
						query = request.Sort.Type == SortTypeEnum.ASC ? query.OrderBy(column_sort) : query.OrderByDescending(column_sort);
					else
						query = query.OrderBy(d=>d.Id);
				}
				#endregion

				var query_count = query;
				if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
					query = query.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value);
				var data_list = await query.ToListAsync();

				result.List = _mapper.Map<List<PenelitianWorkflowResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List PenelitianWorkflow", request);
                result.Error("Failed Get List PenelitianWorkflow", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, bool>> where, Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, object>> result_order = null;
			Expression<Func<Vleko.SiPeneliti.Data.Model.PenelitianWorkflow, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "id" : 
						if(is_where){
							if (Guid.TryParse(search, out var _Id))
								result_where = (d=>d.Id == _Id);
								else
								result_where = (d=>d.Id == Guid.Empty);
						}
						else
							result_order = (d => d.Id);
					break;
					case "callbackurl" : 
						if(is_where){
							result_where = (d=>d.CallbackUrl.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.CallbackUrl);
					break;
					case "createby" : 
						if(is_where){
							result_where = (d=>d.CreateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.CreateBy);
					break;
					case "createdate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _CreateDate))
								result_where = (d=>d.CreateDate == _CreateDate);
						}
						else
							result_order = (d => d.CreateDate);
					break;
					case "groupno" : 
						if(is_where){
							if (int.TryParse(search, out var _GroupNo))
								result_where = (d=>d.GroupNo == _GroupNo);
						}
						else
							result_order = (d => d.GroupNo);
					break;
					case "idpenelitian" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdPenelitian))
								result_where = (d=>d.IdPenelitian == _IdPenelitian);
								else
								result_where = (d=>d.IdPenelitian == Guid.Empty);
						}
						else
							result_order = (d => d.IdPenelitian);
					break;
					case "iduserrequester" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdUserRequester))
								result_where = (d=>d.IdUserRequester == _IdUserRequester);
								else
								result_where = (d=>d.IdUserRequester == Guid.Empty);
						}
						else
							result_order = (d => d.IdUserRequester);
					break;
					case "navigationurl" : 
						if(is_where){
							result_where = (d=>d.NavigationUrl.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NavigationUrl);
					break;
					case "statuscode" : 
						if(is_where){
							if (int.TryParse(search, out var _StatusCode))
								result_where = (d=>d.StatusCode == _StatusCode);
						}
						else
							result_order = (d => d.StatusCode);
					break;
					case "statusdescription" : 
						if(is_where){
							result_where = (d=>d.StatusDescription.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.StatusDescription);
					break;
					case "stepno" : 
						if(is_where){
							if (int.TryParse(search, out var _StepNo))
								result_where = (d=>d.StepNo == _StepNo);
						}
						else
							result_order = (d => d.StepNo);
					break;
					case "updateby" : 
						if(is_where){
							result_where = (d=>d.UpdateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.UpdateBy);
					break;
					case "updatedate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _UpdateDate))
								result_where = (d=>d.UpdateDate == _UpdateDate);
						}
						else
							result_order = (d => d.UpdateDate);
					break;
					case "workflowcode" : 
						if(is_where){
							result_where = (d=>d.WorkflowCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.WorkflowCode);
					break;
					case "workflowname" : 
						if(is_where){
							result_where = (d=>d.WorkflowName.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.WorkflowName);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

