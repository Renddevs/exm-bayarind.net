//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Vleko.SiPeneliti.Core.Request
{
    public partial class UserRequest
    {
		[Required]
		public bool Active{ get; set; }
		[Required]
		public string Fullname{ get; set; }
		[Required]
		public string IdRole{ get; set; }
		[Required]
		public string Mail{ get; set; }
		[Required]
		public string Password{ get; set; }
		[Required]
		public string PhoneNumber{ get; set; }
		public string PhotoBase64{ get; set; }
		public string Token{ get; set; }
		[Required]
		public string Username{ get; set; }

    }
}
