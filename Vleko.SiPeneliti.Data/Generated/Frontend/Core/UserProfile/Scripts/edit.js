//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editUserProfileDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-UserProfile-edit').modal('show');

	$('#Edit-UserProfile-Address').val(data.address);
	$('#Edit-UserProfile-BirthDate').val(data.birthDate);
	$('#Edit-UserProfile-BirthPlace').val(data.birthPlace);
	$('#Edit-UserProfile-Gender').val(data.gender);
	$('#Edit-UserProfile-IdDati').val(data.idDati);
	$('#Edit-UserProfile-Nationality').val(data.nationality);
	$('#Edit-UserProfile-Nik').val(data.nik);
	$('#Edit-UserProfile-Nip').val(data.nip);
	$('#Edit-UserProfile-Profession').val(data.profession);


    $('#md-UserProfile-edit').data('id', data.id);
    $('#UserProfile-edit_btn').unbind();
    $('#UserProfile-edit_btn').on('click', function () {
        editUserProfileSave();
    });
}

function editUserProfileSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				address:$('#Edit-UserProfile-Address').val(),
				birthDate:$('#Edit-UserProfile-BirthDate').val(),
				birthPlace:$('#Edit-UserProfile-BirthPlace').val(),
				gender:$('#Edit-UserProfile-Gender').val(),
				idDati:$('#Edit-UserProfile-IdDati').val(),
				nationality:$('#Edit-UserProfile-Nationality').val(),
				nik:$('#Edit-UserProfile-Nik').val(),
				nip:$('#Edit-UserProfile-Nip').val(),
				profession:$('#Edit-UserProfile-Profession').val(),

            }
            RequestData('PUT', `/v1/UserProfile/edit/${$('#md-UserProfile-edit').data('id')}`, '#md-UserProfile-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-UserProfile-edit').modal('hide');
                    getListUserProfile();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}