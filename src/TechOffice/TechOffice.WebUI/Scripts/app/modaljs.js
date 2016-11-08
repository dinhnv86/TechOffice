var url = '';
var idButtonDelete = '';

$(document).ready(function () {

    onNewMaster();
    onEditMaster();
});

$('#modalCreateNew').on('shown.bs.modal', function () {
    $('#txtName').focus();
});
$('#modalEdit').on('shown.bs.modal', function () {
    $('#txtNameEdit').focus();
});
$('#modalCreateNew').on('hidden.bs.modal', function () {
    $('#txtName').val('');
    $('#txtDescription').val('');
});
$('#modalEdit').on('hidden.bs.modal', function () {
    $('#txtNameEdit').val('');
    $('#txtDescriptionEdit').val('');
});

onAddMSTBegin = function () {
    $('#screen').css({ opacity: 0.2, 'width': $(document).width(), 'height': $(document).height() });
    $('body').css({ 'overflow': 'hidden' });
    $('#box').css({ 'display': 'block' });

    $('#modalCreateNew').modal('hide');
};
onAddMSTFailure = function () {
    //Show Failure
    if (res.code == "SB02") {
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#danger-alert").css('display', 'none');
        });
    }
};
onAddMSTComplete = function () {
    onHideLoading();
};

onEditMSTBegin = function () {
    onShowLoading();
    $('#modalEdit').modal('hide');
};

onEditMSTFailure = function () {
    //Show Failure
    if (res.code == "SB02") {
        $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#danger-alert").css('display', 'none');
        });
    }
};

onEditMSTComplete = function () {
    onAddMSTComplete();
}

onShowLoading = function () {
    $('#screen').css({ opacity: 0.2, 'width': $(document).width(), 'height': $(document).height() });
    $('body').css({ 'overflow': 'hidden' });
    $('#box').css({ 'display': 'block' });
}

onHideLoading = function () {
    $('#screen').css({ opacity: 0.2, 'width': 0, 'height': 0 });
    $('body').css({ 'overflow': 'show' });
    $('#box').css({ 'display': 'none' });
    $('html').css('overflow', '-moz-scrollbars-vertical');
    $('html').css('overflow-y', 'scroll');
}

onEditMaster = function () {
    $('#tblMST').on('click', '.btn-edit', function (event) {
        event.preventDefault();
        var url = $(this).attr('href');

        $('#modalEditBody').load(url);
        $('#modalEdit').modal('show');
    });
}

onNewMaster = function () {
    $('#lnkCreateNew').on('click', function (event) {
        event.preventDefault();
        $('#modalCreateNew').modal('show');
    });
}

onAlertSuccess = function () {
    $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#success-alert").css('display', 'none');
    });
}

onAlertFailure = function () {
    $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#success-alert").css('display', 'none');
    });
}