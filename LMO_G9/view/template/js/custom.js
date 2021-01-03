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
            window.location.href = window.location.origin.concat(msg.d);
        }
    });
};

function clear() {
    $('input').text('');
}

// function call method in c#
function saveCategory(linkPage, idName) {
    var data = $('#' + idName).val();
    //if (validateCategory(data)) {
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
    /*} else {
        txtError.text('Bạn vui lòng nhập tên loại nhạc');
        return;
    }*/
}

function validateCategory(nameCategory) {
    if (nameCategory == null || nameCategory == "") {
        return false;
    }
    return true;
}

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

function saveSinger(singerName, imgPath) {
    var singerNameC = $('#' + singerName).val();
    var imgPathC = $('#' + imgPath).val();
    $.ajax({
        type: 'POST',
        url: 'singer.aspx/saveSinger',
        data: '{singerName: "' + singerNameC + '", imgPath: "' + imgPathC + '"}',
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

function saveNew(newTitle, imgPath, shortContent, content) {
    var newTitleC = $('#' + newTitle).val();
    var s_contentC = $('#' + shortContent).val();
    var contentC = $('#' + content).val();
    var imgPathC = $('#' + imgPath).val();
    $.ajax({
        type: 'POST',
        url: 'singer.aspx/saveSinger',
        data: '{singerName: "' + newTitleC + '", imgPath: "' + imgPathC + '" , shortContent: "' + s_contentC + '" , content: "' + contentC + '"}',
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