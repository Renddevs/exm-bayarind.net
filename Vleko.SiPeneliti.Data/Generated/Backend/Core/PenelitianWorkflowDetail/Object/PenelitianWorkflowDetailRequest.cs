//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Vleko.SiPeneliti.Core.Request
{
    public partial class PenelitianWorkflowDetailRequest
    {
		[Required]
		public int GroupNo{ get; set; }
		[Required]
		public Guid IdPenelitianWorkflow{ get; set; }
		[Required]
		public Guid IdUser{ get; set; }
		[Required]
		public bool IsReviewer{ get; set; }
		[Required]
		public string StepName{ get; set; }
		[Required]
		public int StepNo{ get; set; }

    }
}
