//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function deletePenelitianWorkflowDetailDialog(id) {
    ConfirmMessage('Apakah Anda Yakin Akan Menghapus Data Ini?', isConfirm => {
        if (isConfirm) {
            var element = {
                tbody: '#PenelitianWorkflowDetail-tbody',
                tcontainer: '#PenelitianWorkflowDetail-table',
            };
            RequestData('DELETE', `/v1/PenelitianWorkflowDetail/delete/${id}`, element.tcontainer, element.tbody, null, function (data) {
                if (data.succeeded) {
                    ShowNotif("Data Deleted Successfully ...", "success");
                    getListPenelitianWorkflowDetail();
                } else
                    ShowNotif(`${data.message} : ${data.description}`, "error");
            });
        }
    });
}