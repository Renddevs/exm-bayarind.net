//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailPenelitianWorkflowLogDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-PenelitianWorkflowLog-detail').modal('show');

				$('#Detail-PenelitianWorkflowLog-GroupNo').val(data.groupNo);
				$('#Detail-PenelitianWorkflowLog-IdPenelitianWorkflow').val(data.idPenelitianWorkflow);
				$('#Detail-PenelitianWorkflowLog-IdUser').val(data.idUser);
				$('#Detail-PenelitianWorkflowLog-IdWorkflowStatus').val(data.idWorkflowStatus);
				$('#Detail-PenelitianWorkflowLog-IsReviewer').prop('checked', data.isReviewer);
				$('#Detail-PenelitianWorkflowLog-Notes').val(data.notes);
				$('#Detail-PenelitianWorkflowLog-StatusDescription').val(data.statusDescription);
				$('#Detail-PenelitianWorkflowLog-StepName').val(data.stepName);
				$('#Detail-PenelitianWorkflowLog-StepNo').val(data.stepNo);

}
