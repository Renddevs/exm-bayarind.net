function ShowLoading(target, effect = 'win8', message = '', callback = null) {
    $(target).waitMe({
        effect: effect,
        text: message !== undefined || message !== null ? message : '',
        bg: 'rgba(255,255,255,0.7)',
        color: '#00558b',
        maxSize: '',
        waitTime: -1,
        textPos: 'vertical',
        fontSize: '',
        source: '',
        onClose: callback !== undefined && callback !== null ? callback : function () {
        }
    });
}

function ShowNotif(message, type) {
    $.notify(message, type);
}