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
    public partial class PenelitianAnggotaResponse: IMapResponse<PenelitianAnggotaResponse, Vleko.SiPeneliti.Data.Model.PenelitianAnggota>
    {
		public Guid Id{ get; set; }
		public DateTime BirthDate{ get; set; }
		public string BirthPlace{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Fullname{ get; set; }
		public Guid IdPenelitian{ get; set; }
		public string Nik{ get; set; }
		public string Nip{ get; set; }
		public string Profession{ get; set; }
		public int Sort{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Vleko.SiPeneliti.Data.Model.PenelitianAnggota, PenelitianAnggotaResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}
