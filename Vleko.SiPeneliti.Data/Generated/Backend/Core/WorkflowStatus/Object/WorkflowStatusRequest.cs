//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Vleko.SiPeneliti.Core.Request
{
    public partial class WorkflowStatusRequest
    {
		[Required]
		public bool Active{ get; set; }
		[Required]
		public string Name{ get; set; }

    }
}

