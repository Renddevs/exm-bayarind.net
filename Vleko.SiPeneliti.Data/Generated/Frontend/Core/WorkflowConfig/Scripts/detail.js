//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailWorkflowConfigDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-WorkflowConfig-detail').modal('show');

				$('#Detail-WorkflowConfig-Active').prop('checked', data.active);
				$('#Detail-WorkflowConfig-CallbackUrl').val(data.callbackUrl);
				$('#Detail-WorkflowConfig-Code').val(data.code);
				$('#Detail-WorkflowConfig-Name').val(data.name);
				$('#Detail-WorkflowConfig-NavigationUrl').val(data.navigationUrl);

}
