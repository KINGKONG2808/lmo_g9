(function () {
    clear();
})();

// function logout admin
function logout() {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/logout',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            redirectPage(msg.d);
        }
    });
};

function redirectPage(link) {
    var currentHost = window.location.origin;
    window.location.href = currentHost.concat(link);
}

function clear() {
    $('input').text('');
}

// function call method in c#
function saveCategory(linkPage, idName) {
    var data = $('#' + idName).val();
    $.ajax({
        type: 'POST',
        url: linkPage,
        data: '{categoryName: "' + data + '"}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            alert(msg.d);
            window.location.reload();
        },
        error: function (msg) {
            alert(msg.d);
        }
    });
}

// function call method in c#
function saveComposer(composerName, imgPath) {
    var composerNameC = $('#' + composerName).val();
    var imgPathC = $('#' + imgPath).val();
    $.ajax({
        type: 'POST',
        url: 'composer.aspx/saveComposer',
        data: '{composerName: "' + composerNameC + '", imgPath: "' + imgPathC + '"}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            alert(msg.d);
            window.location.reload();
        },
        error: function (msg) {
            alert(msg.d);
        }
    });
}

function onShowModal(modalId) {
    $('#' + modalId).modal('show');
}