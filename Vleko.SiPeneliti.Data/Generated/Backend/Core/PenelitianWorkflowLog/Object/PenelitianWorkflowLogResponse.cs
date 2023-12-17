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
    public partial class PenelitianWorkflowLogResponse: IMapResponse<PenelitianWorkflowLogResponse, Vleko.SiPeneliti.Data.Model.PenelitianWorkflowLog>
    {
		public Guid Id{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public int GroupNo{ get; set; }
		public Guid IdPenelitianWorkflow{ get; set; }
		public Guid IdUser{ get; set; }
		public short IdWorkflowStatus{ get; set; }
		public bool IsReviewer{ get; set; }
		public string Notes{ get; set; }
		public string StatusDescription{ get; set; }
		public string StepName{ get; set; }
		public int StepNo{ get; set; }


        public void Mapping(IMappingExpression<Vleko.SiPeneliti.Data.Model.PenelitianWorkflowLog, PenelitianWorkflowLogResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

