//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailPenelitianWorkflowDetailDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-PenelitianWorkflowDetail-detail').modal('show');

				$('#Detail-PenelitianWorkflowDetail-GroupNo').val(data.groupNo);
				$('#Detail-PenelitianWorkflowDetail-IdPenelitianWorkflow').val(data.idPenelitianWorkflow);
				$('#Detail-PenelitianWorkflowDetail-IdUser').val(data.idUser);
				$('#Detail-PenelitianWorkflowDetail-IsReviewer').prop('checked', data.isReviewer);
				$('#Detail-PenelitianWorkflowDetail-StepName').val(data.stepName);
				$('#Detail-PenelitianWorkflowDetail-StepNo').val(data.stepNo);

}
