//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailRoleDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Role-detail').modal('show');

				$('#Detail-Role-Active').prop('checked', data.active);
				$('#Detail-Role-Name').val(data.name);

}
