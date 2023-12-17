//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#BidangPenelitian-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-BidangPenelitian-add').modal('show');
        $('#BidangPenelitian-create_btn').unbind();
        $('#BidangPenelitian-create_btn').on('click', function () {
            addBidangPenelitianSave();
        });
    });
});

function addBidangPenelitianSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				active:$('#Add-BidangPenelitian-Active').is(":checked"),
				name:$('#Add-BidangPenelitian-Name').val(),

            }
            RequestData('POST', `/v1/BidangPenelitian/add`, '#md-BidangPenelitian-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-BidangPenelitian-add').modal('hide');
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
