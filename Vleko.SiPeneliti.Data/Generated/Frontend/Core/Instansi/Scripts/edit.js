//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editInstansiDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Instansi-edit').modal('show');

	$('#Edit-Instansi-Active').prop('checked', data.active);
	$('#Edit-Instansi-Name').val(data.name);


    $('#md-Instansi-edit').data('id', data.id);
    $('#Instansi-edit_btn').unbind();
    $('#Instansi-edit_btn').on('click', function () {
        editInstansiSave();
    });
}

function editInstansiSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				active:$('#Edit-Instansi-Active').is(":checked"),
				name:$('#Edit-Instansi-Name').val(),

            }
            RequestData('PUT', `/v1/Instansi/edit/${$('#md-Instansi-edit').data('id')}`, '#md-Instansi-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-Instansi-edit').modal('hide');
                    getListInstansi();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}