//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Vleko.SiPeneliti.Core.Request
{
    public partial class PenelitianAnggotaRequest
    {
		[Required]
		public DateTime BirthDate{ get; set; }
		public string BirthPlace{ get; set; }
		[Required]
		public string Fullname{ get; set; }
		[Required]
		public Guid IdPenelitian{ get; set; }
		[Required]
		public string Nik{ get; set; }
		public string Nip{ get; set; }
		[Required]
		public string Profession{ get; set; }
		[Required]
		public int Sort{ get; set; }

    }
}

