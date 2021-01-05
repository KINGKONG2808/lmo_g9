(function () {
    renderLogin();
    renderFavorite();
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

function changeMusic(id) {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/click',
        data: '{id: "' + id + '"}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            $("#content_image").attr('src',msg.d.ImagePath);
            $("#content_sourcemp3").attr('src',msg.d.AudioPath);
            $("#content_sourceogg").attr('src',msg.d.AudioPath);
            $("#content_musicName").text(msg.d.Name);
            $("#content_composerName").text(msg.d.ComposerName);
            $("#content_singerName").text(msg.d.SingerName);
            var music = document.getElementById("music");
            music.load();
            var playButton = document.getElementById("play");
            var pauseButton = document.getElementById("pause");
            playButton.style.visibility = "visible";
            pause.style.visibility = "hidden";

        }
    });
};

function renderFavorite() {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/renderFavorite',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            msg.d.map((n) => {
                $('#unfavorite_' + n).attr('style', 'display:none;')
                $('#favorite_' + n).attr('style', 'display: block;')
            });
        }
    });
};

function addtoFavorite(id) {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/addToFavorite',
        data: '{id: "' + id + '"}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            if (msg.d != null) {
                msg.d.map((n) => {
                    $('#unfavorite_' + n).attr('style', 'display:none;');
                    $('#favorite_' + n).attr('style', 'display: block;');
                });
            } else {
                window.location = 'signin.aspx';
            }
        }
    });
};

function deleteFavorite(id) {
    $.ajax({
        type: 'POST',
        url: 'index.aspx/addToFavorite',
        data: '{id: "' + id + '"}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            if (msg.d != null) {
                msg.d.map((n) => {
                    $('#unfavorite_' + n).attr('style', 'display:none;');
                    $('#favorite_' + n).attr('style', 'display: block;');
                });
            } 
        }
    });
};