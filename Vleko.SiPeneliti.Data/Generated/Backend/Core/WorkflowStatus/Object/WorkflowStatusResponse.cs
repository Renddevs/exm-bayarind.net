//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Vleko.SiPeneliti.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vleko.SiPeneliti.Data.Model;

namespace Vleko.SiPeneliti.Core.Response
{
    public partial class WorkflowStatusResponse: IMapResponse<WorkflowStatusResponse, Vleko.SiPeneliti.Data.Model.WorkflowStatus>
    {
		public short Id{ get; set; }
		public bool Active{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Name{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDAte{ get; set; }


        public void Mapping(IMappingExpression<Vleko.SiPeneliti.Data.Model.WorkflowStatus, WorkflowStatusResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

