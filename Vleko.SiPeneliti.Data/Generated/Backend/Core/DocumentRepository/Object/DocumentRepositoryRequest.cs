//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Vleko.SiPeneliti.Core.Request
{
    public partial class DocumentRepositoryRequest
    {
		[Required]
		public string Base64{ get; set; }
		[Required]
		public string Code{ get; set; }
		public string Description{ get; set; }
		[Required]
		public string Filename{ get; set; }
		[Required]
		public string Modul{ get; set; }
		public string Subject{ get; set; }

    }
}

