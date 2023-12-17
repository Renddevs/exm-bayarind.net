//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#User-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-User-add').modal('show');
        $('#User-create_btn').unbind();
        $('#User-create_btn').on('click', function () {
            addUserSave();
        });
    });
});

function addUserSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				active:$('#Add-User-Active').is(":checked"),
				fullname:$('#Add-User-Fullname').val(),
				idRole:$('#Add-User-IdRole').val(),
				mail:$('#Add-User-Mail').val(),
				password:$('#Add-User-Password').val(),
				phoneNumber:$('#Add-User-PhoneNumber').val(),
				photoBase64:$('#Add-User-PhotoBase64').val(),
				token:$('#Add-User-Token').val(),
				username:$('#Add-User-Username').val(),

            }
            RequestData('POST', `/v1/User/add`, '#md-User-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-User-add').modal('hide');
                    getListUser();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
