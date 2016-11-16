$(document).ready(function () {
    var timer;
    var delay = 600; // 0.6 seconds delay after last input

    $('#txtUserName').on('keyup', function () {
        var data = $(this).val();

        window.clearTimeout(timer);
        timer = window.setTimeout(function () {
            $.ajax({
                async: false,
                type: 'POST',
                cache: false,
                url: '@Url.Action("CheckUserName","Users")',
                data: { userName: data },
                success: function (result) {
                    if (result !== undefined && result == '1') {
                        $('#duplicateUserName').text(message.DuplicateUser);
                        $('#btnSaveSubmit').attr('disabled', true);
                    }
                    else {
                        $('#duplicateUserName').text('');
                        $('#btnSaveSubmit').attr('disabled', false);
                    }
                }
            });
        }, delay);
    });
});
/*BEGIN NEW REQUEST*/
onBegin = function () {
    onShowLoading();
}
onSuccess = function (data) {
    $('#txtFullName').val('');
    $('#txtUserName').val('');
    $('#txtChucVu').val('');
    $('#txtCoquan').val('');
    $("input[type='checkbox]").val(false);
    onHideLoading();

    $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#success-alert").css('display', 'none');
    });

    window.location.href = '/users';
}
onFailure = function (data) {
    $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#danger-alert").css('display', 'none');
    });
}
onComplete = function () {
    onHideLoading();
}
