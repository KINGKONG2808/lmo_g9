(function () {
    renderLogin();
})();

function renderLogin() {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/onRenderLogin',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            var result = msg.d;
            if (result !== null) {
                $('#login').addClass('none');
                $('#login').parent().addClass('no-padding');
                $('#profile-customer').removeClass('none');
                $('#fullname').text(result);
            }
        }
    });
};

function logout() {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/logout',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: setTimeout(
            function (msg) {
                $('#login').removeClass('none');
                $('#login').parent().removeClass('no-padding');
                $('#profile-customer').addClass('none');
                window.location.href = window.location.origin.concat(msg.d);
            }, 1000
        )
    });
};