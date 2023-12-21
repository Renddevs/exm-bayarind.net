function RequestData(type, url, container, field, params, callback, isJson = true) {
    var config = {
        async: true,
        type: type,
        url: "https://localhost:44342/api/v1/" + url,
        contentType: "application/json",
        data: params,
        beforeSend: function (xhr) {
            if (container != undefined && container != null && container != "")
                ShowLoading(container);
        },
        error: function (err) {
            console.log(err);
            if (container != undefined && container != null && container != "")
                $(container).waitMe('hide');
            ShowNotif("Something went wrong", "error");
        },
        success: function (data) {
            if (field != undefined && field != null && field != "")
                $(field).html('');

            if (container != undefined && container != null && container != "")
                $(container).waitMe('hide');

            if (callback != undefined && callback != null && callback != "")
                return callback(data);
        }
    };

    if (isJson)
        config.dataType = 'json';

    $.ajax(config);
}