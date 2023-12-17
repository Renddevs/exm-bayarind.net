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

namespace Vleko.SiPeneliti.Core.UserProfile.Query
{
    public class GetUserProfileListRequest : ListRequest,IListRequest<GetUserProfileListRequest>,IRequest<ListResponse<UserProfileResponse>>
    {
    }
    internal class GetUserProfileListHandler : IRequestHandler<GetUserProfileListRequest, ListResponse<UserProfileResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserProfileListHandler(
            ILogger<GetUserProfileListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<UserProfileResponse>> Handle(GetUserProfileListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<UserProfileResponse> result = new ListResponse<UserProfileResponse>();
            try
            {
				var query = _context.Entity<Vleko.SiPeneliti.Data.Model.UserProfile>().AsQueryable();

				#region Filter
				Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, object>> column_sort = null;
				List<Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, bool>>> where = new List<Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, bool>>>();
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

				result.List = _mapper.Map<List<UserProfileResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List UserProfile", request);
                result.Error("Failed Get List UserProfile", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, bool>> where, Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, object>> result_order = null;
			Expression<Func<Vleko.SiPeneliti.Data.Model.UserProfile, bool>> result_where = null;
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
					case "address" : 
						if(is_where){
							result_where = (d=>d.Address.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Address);
					break;
					case "birthdate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _BirthDate))
								result_where = (d=>d.BirthDate == _BirthDate);
						}
						else
							result_order = (d => d.BirthDate);
					break;
					case "birthplace" : 
						if(is_where){
							result_where = (d=>d.BirthPlace.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BirthPlace);
					break;
					case "gender" : 
						if(is_where){
							result_where = (d=>d.Gender.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Gender);
					break;
					case "iddati" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdDati))
								result_where = (d=>d.IdDati == _IdDati);
								else
								result_where = (d=>d.IdDati == Guid.Empty);
						}
						else
							result_order = (d => d.IdDati);
					break;
					case "nationality" : 
						if(is_where){
							result_where = (d=>d.Nationality.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Nationality);
					break;
					case "nik" : 
						if(is_where){
							result_where = (d=>d.Nik.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Nik);
					break;
					case "nip" : 
						if(is_where){
							result_where = (d=>d.Nip.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Nip);
					break;
					case "profession" : 
						if(is_where){
							result_where = (d=>d.Profession.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Profession);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}
