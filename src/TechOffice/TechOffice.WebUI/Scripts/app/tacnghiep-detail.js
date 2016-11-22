$(document).ready(function () {

    var optionCalendar =
     {
         autoSize: true,
         constrainInput: true,
         minDate: 0,
         dateFormat: 'dd/mm/yy'
     };
    $('.control-datepicker').datepicker(optionCalendar);

    $.validator.addMethod('date',
    function (value, element) {
        if (this.optional(element)) {
            return true;
        }

        var ok = true;
        try {
            $.datepicker.parseDate('dd/mm/yy', value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });

    $('#modalEditBody').height(260);

    $('#formYKienCoQuan').on('click', '.btn-edit', function (event) {
        event.preventDefault();
        var url = $(this).attr('href');

        $('#modalEditBody').load(url);
        $('#modalEditYKienCoQuan').modal({ backdrop: 'static', keyboard: false, show: true });
    });

    onEditYKienBegin = function () {
        onShowLoading();
    };
    onEditYKienComplete = function () {
        onHideLoading();
    };
    onEditYKienSuccess = function () {
        //reload page
        var url = window.location.href;
        window.location.href = url;
    };
    onEditYKienFailure = function () {
        alert("Đã xảy ra lỗi trong quá trình cập nhật. Xin vui lòng thử lại");
    };

    onAddYKienBegin = function () {
        onShowLoading();
    };
    onAddYKienComplete = function () {
        onHideLoading();
    };
    onAddYKienSuccess = function () {
        //reload page
        var url = window.location.href;
        window.location.href = url;
    };
    onAddYKienFailure = function () {
        alert("Đã xảy ra lỗi trong quá trình cập nhật. Xin vui lòng thử lại");
    };

    onEditBegin = function () {
        onShowLoading();
    };
    onEditComplete = function () {
        onHideLoading();
    };
    onEditSuccess = function () {
        //reload page
        var url = window.location.href;
        window.location.href = url;
    };
    onEditFailure = function () {
        alert("Đã xảy ra lỗi trong quá trình cập nhật. Xin vui lòng thử lại");
    };

    $('#formYKienCoQuan').on('change', 'input[type="file"]', function (e) {
        $('#spanUpload').text('');
        var files = e.originalEvent.target.files;
        if (files.length > 0) {
            $(this).next().removeAttr('disabled');
        }
        else {
            $(this).next().attr('disabled', 'disabled');
        }
    });

    //Upload files
    $('input[type="file"]').change(function (e) {
        $('#spanUpload').text('');
        var files = e.originalEvent.target.files;
        if (files.length > 0) {
            $(this).next().removeAttr('disabled');
        }
        else {
            $(this).next().attr('disabled', 'disabled');
        }
    });
});