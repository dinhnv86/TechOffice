$(document).ready(function () {
    $('#tableAdmin').on('click', '.btn-link', function (event) {
        event.preventDefault();
        var url = $(this).attr('href');

        $('#modalPopupDetailBody').load(url);
        $('#modalPopupDetail').modal({ backdrop: 'static', keyboard: false, show: true });
    });

    $('#modalPopupDetail').on('show.bs.modal', function () {
        $(this).find('.modal-body').css({
            width: 'auto', //probably not needed
            height: 'auto', //probably not needed
            'overflow-y': 'auto',
            'max-height': '100%'
        });
    });
});