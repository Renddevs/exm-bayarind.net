//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editBidangPenelitianDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-BidangPenelitian-edit').modal('show');

	$('#Edit-BidangPenelitian-Active').prop('checked', data.active);
	$('#Edit-BidangPenelitian-Name').val(data.name);


    $('#md-BidangPenelitian-edit').data('id', data.id);
    $('#BidangPenelitian-edit_btn').unbind();
    $('#BidangPenelitian-edit_btn').on('click', function () {
        editBidangPenelitianSave();
    });
}

function editBidangPenelitianSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				active:$('#Edit-BidangPenelitian-Active').is(":checked"),
				name:$('#Edit-BidangPenelitian-Name').val(),

            }
            RequestData('PUT', `/v1/BidangPenelitian/edit/${$('#md-BidangPenelitian-edit').data('id')}`, '#md-BidangPenelitian-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-BidangPenelitian-edit').modal('hide');
                    getListBidangPenelitian();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
