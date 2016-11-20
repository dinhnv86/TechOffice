/// <reference path="../jquery-1.12.4.js" />
$(document).ready(function () {
    var isAddModeVanBan = true;
    var valueEditId = 0;
    var rowEditingVanBan = undefined;

    var isAddModeXuLy = true;
    var rowEditingXuLy = undefined;

    $('#VanBanLienQuanViewModel_0__Ngay').removeClass('control-datepicker');

    var optionCalendarDefault =
     {
         autoSize: true,
         constrainInput: true,
         dateFormat: 'dd/mm/yy',
     };

    var optionCalendar = {
        autoSize: true,
        constrainInput: true,
        dateFormat: 'dd/mm/yy',
        minDate: new Date(),
    };

    $('.control-datepicker').datepicker(optionCalendar);

    $('#VanBanLienQuanViewModel_0__Ngay').datepicker(optionCalendarDefault);

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

    $('#btnAddVanBanLienQuan').on('click', function () {
        if (isAddModeVanBan) {
            addRowVanBan();
        }
        else {
            editRowVanBan();
        }
    });

    $('#btnAddQuaTrinhXuLy').on('click', function () {
        if (isAddModeXuLy) {
            addRowXuLy();
        }
        else {
            editRowXuLy();
        }
    });

    $('#tbodyAddVanBan').on('click', '.btnDeleteTemp', function () {
        deleteRow(this);
    });

    $('#tbodyAddVanBan').on('click', '.btnEditTemp', function () {
        var listTD = $(this).closest('tr').find('td');
        var soVanBan = listTD.eq(0).text();
        var ngay = listTD.eq(1).text();
        var noiDung = listTD.eq(2).text();
        var coQuanId = listTD.eq(3).find('input').eq(0).val();

        $('#VanBanLienQuanViewModel_0__SoVanBan').val(soVanBan);
        $('#VanBanLienQuanViewModel_0__Ngay').val(ngay);
        $('#VanBanLienQuanViewModel_0__NoiDung').val(noiDung);
        $('#VanBanLienQuanViewModel_0__CoQuanId').val(coQuanId);

        valueEditId = ($(this).attr('id'));
        rowEditingVanBan = listTD;
        isAddModeVanBan = false;
    });

    $('#tbodyAddQuaTrinhXuLy').on('click', '.btnDeleteTemp', function () {
        deleteRow(this);
    });

    $('#tbodyAddQuaTrinhXuLy').on('click', '.btnEditTemp', function () {
        var listTD = $(this).closest('tr').find('td');
        var noiDung = listTD.eq(2).text();
        var mucDoId = $(listTD.eq(1).find('input:last')[0]).val();

        $('#QuaTrinhXuLyViewModel_0__NoiDung').val(noiDung);
        $('#QuaTrinhXuLyViewModel_0__NhacNho').val(mucDoId);

        valueEditId = ($(this).attr('id'));
        rowEditingXuLy = listTD;
        isAddModeXuLy = false;
    });

    /*Add, edit, delete row*/
    function addRowVanBan() {
        var soVanBan = $('#VanBanLienQuanViewModel_0__SoVanBan').val();
        var ngay = $('#VanBanLienQuanViewModel_0__Ngay').val();
        var noiDung = $('#VanBanLienQuanViewModel_0__NoiDung').val();
        var nameCoQuan = $('#VanBanLienQuanViewModel_0__CoQuanId option:selected').text();
        var coQuanId = $('#VanBanLienQuanViewModel_0__CoQuanId').val();
        var tbody = $('#tbodyAddVanBan > tr');
        var tbody_len = (tbody.length);
        var template = ('<tr>' +
        '<td>' + '<input id="VanBanLienQuanViewModel_' + tbody_len + '__SoVanBan" name="VanBanLienQuanViewModel[' + tbody_len + '].SoVanBan" type="hidden" value="' + soVanBan + '">' + '<span>' + soVanBan + '</span>' + '</td>'
        + '<td>' + '<input id="VanBanLienQuanViewModel_' + tbody_len + '__Ngay" name="VanBanLienQuanViewModel[' + tbody_len + '].Ngay" type="hidden" value="' + ngay + '">' + '<span>' + ngay + '</span>' + '</td>'
        + '<td>' + '<input id="VanBanLienQuanViewModel_' + tbody_len + '__NoiDung" name="VanBanLienQuanViewModel[' + tbody_len + '].NoiDung" type="hidden" value="' + noiDung + '">' + '<span>' + noiDung + '</span>' + '</td>'
        + '<td>' + '<input id="VanBanLienQuanViewModel_' + tbody_len + '__CoQuanId" name="VanBanLienQuanViewModel[' + tbody_len + '].CoQuanId" type="hidden" value="' + coQuanId + '">' + '<span>' + nameCoQuan + '</span>' + '</td>'
        + '<td>' + '<input type="button" value="Xóa" class="btn btn-link btnDeleteTemp" id="btnDeleteTemp_' + tbody_len + '"/>|<input type="button" value="Sửa" class="btn btn-link btnEditTemp" id="btnEditTemp_' + tbody_len + '"/>' + '</td>'
        + '</tr>');

        var row = $('table#tableAddVanBan > tbody > tr:last').before(template);

        resetRowTemplateVanBan();
    }

    function editRowVanBan() {
        if (rowEditingVanBan != undefined) {
            var soVanBan = $("#VanBanLienQuanViewModel_0__SoVanBan").val();
            var ngay = $("#VanBanLienQuanViewModel_0__Ngay").val();
            var noiDung = $("#VanBanLienQuanViewModel_0__NoiDung").val();
            var coQuanId = $("#VanBanLienQuanViewModel_0__CoQuanId").val();
            var nameCoQuan = $('#VanBanLienQuanViewModel_0__CoQuanId option:selected').text();

            $(rowEditingVanBan).eq(0).each(function () {
                $(this).find("input[type='hidden']").val(soVanBan);
                $(this).find('span').text(soVanBan);
            });

            $(rowEditingVanBan).eq(1).each(function () {
                $(this).find("input[type='hidden']").val(ngay);
                $(this).find('span').text(ngay);
            });

            $(rowEditingVanBan).eq(2).each(function () {
                $(this).find('input[type="hidden"]').val(noiDung);
                $(this).find('span').text(noiDung);
            });

            $(rowEditingVanBan).eq(3).each(function () {
                $(this).find('input[type="hidden"]').val(coQuanId);
                $(this).find('span').text(nameCoQuan);
            });

            isAddModeVanBan = true;
            rowEditingVanBan = undefined;

            //reset row template add in GUI, except ngay input
            resetRowTemplateVanBan();
        }
    }

    function deleteRow(rowDeleted) {
        $(rowDeleted).closest('tr').nextAll('tr').each(function () {
            $(this).find('td').each(function () {
                var input = $(this).find('input[type="hidden"]').each(function () {
                    var id = $(this).attr('id');
                    var name = $(this).attr('name');

                    if (id != undefined) {
                        var suffix = id.match(/\d+/);
                        if (suffix > 0) {
                            $(this).attr('id', id.replace(/\d+/, suffix - 1));
                            $(this).attr('name', name.replace(/\d+/, suffix - 1));
                        }
                    }
                });
            });
        });

        $(rowDeleted).closest('tr').remove();
    }

    function addRowXuLy() {
        var vanBan = $('#QuaTrinhXuLyViewModel_0__NoiDung').val();
        var nguoiThem = $('#QuaTrinhXuLyViewModel_0__NguoiThem').val();
        var mucDoId = $('#QuaTrinhXuLyViewModel_0__NhacNho').val();

        var tbody = $('#tbodyAddQuaTrinhXuLy > tr');
        var tbody_len = (tbody.length);
        var template = ('<tr>' +
        '<td>' +
            '<input id="QuaTrinhXuLyViewModel_' + tbody_len + '__Gio" name="QuaTrinhXuLyViewModel[' + tbody_len + '].Gio" type="hidden" value=' + getHours() + '>' +
            '<input id="QuaTrinhXuLyViewModel_' + tbody_len + '__Phut" name="QuaTrinhXuLyViewModel[' + tbody_len + '].Phut" type="hidden" value=' + getMinutes() + '>' +
            '<span>' + getHours() + '</span>' + ':' + '<span>' + getMinutes() + '</span>' +
        '</td>'
        + '<td>' +
            '<input id="QuaTrinhXuLyViewModel_' + tbody_len + '__Ngay" name="QuaTrinhXuLyViewModel[' + tbody_len + '].Ngay" type="hidden" value=' + formatDate() + '>' +
            '<input id="QuaTrinhXuLyViewModel_' + tbody_len + '__NhacNho" name="QuaTrinhXuLyViewModel[' + tbody_len + '].NhacNho" type="hidden" value=' + mucDoId + '>' +
            '<span>' + formatDate() + '</span>'
        + '</td>'
        + '<td>' + '<input id="QuaTrinhXuLyViewModel_' + tbody_len + '__NoiDung" name="QuaTrinhXuLyViewModel[' + tbody_len + '].NoiDung" type="hidden" value="' + vanBan + '">' + '<span>' + vanBan + '</span>' + '</td>'
        + '<td>' + '<input id="QuaTrinhXuLyViewModel_' + tbody_len + '__CoQuanId" name="QuaTrinhXuLyViewModel[' + tbody_len + '].NguoiThem" type="hidden" value="' + nguoiThem + '">' + '<span>' + nguoiThem + '</span>' + '</td>'
        + '<td>' + '<input type="button" value="Xóa" class="btn btn-link btnDeleteTemp" id="btnDeleteTemp_' + tbody_len + '"/>|<input type="button" value="Sửa" class="btn btn-link btnEditTemp" id="btnEditTemp_' + tbody_len + '"/>' + '</td>'
        + '</tr>');

        var row = $('tbody#tbodyAddQuaTrinhXuLy > tr:last').before(template);

        resetRowTempalteXuLy();
    }

    function editRowXuLy() {
        if (rowEditingXuLy != undefined) {

            var noiDung = $("#QuaTrinhXuLyViewModel_0__NoiDung").val();
            var mucDoId = $("#QuaTrinhXuLyViewModel_0__NhacNho").val();

            $(rowEditingXuLy).eq(0).each(function () {
                $(this).find("input[type='hidden']:first").val(getHours());
                $(this).find("input[type='hidden']:last").val(getMinutes());
                $(this).find('span:first').text(getHours());
                $(this).find('span:last').text(getMinutes());
            });

            $(rowEditingXuLy).eq(1).each(function () {
                $(this).find("input[type='hidden']:first").val(formatDate());
                $(this).find("input[type='hidden']:last").val(mucDoId);
                $(this).find('span').text(formatDate());
            });

            $(rowEditingXuLy).eq(2).each(function () {
                $(this).find('input[type="hidden"]').val(noiDung);
                $(this).find('span').text(noiDung);
            });

            isAddModeXuLy = true;
            rowEditingXuLy = undefined;

            resetRowTempalteXuLy();
        }
    }

    //check validate value
    $('#VanBanLienQuanViewModel_0__SoVanBan, #VanBanLienQuanViewModel_0__Ngay, #VanBanLienQuanViewModel_0__NoiDung').keyup(function () {
        if (validateValueVanBan())
            $('#btnAddVanBanLienQuan').attr('disabled', false);
        else
            $('#btnAddVanBanLienQuan').attr('disabled', true);
    });

    $('#VanBanLienQuanViewModel_0__CoQuanId').on('change', function () {
        if (validateValueVanBan())
            $('#btnAddVanBanLienQuan').attr('disabled', false);
        else
            $('#btnAddVanBanLienQuan').attr('disabled', true);
    });

    $('#QuaTrinhXuLyViewModel_0__NoiDung').keyup(function () {
        var noiDung = ($(this).val());

        if (noiDung == '' || noiDung == undefined) {
            $('#btnAddQuaTrinhXuLy').attr('disabled', true);
            return;
        }
        $('#btnAddQuaTrinhXuLy').attr('disabled', false);
    });

    validateValueVanBan = function () {
        var soVanBan = ($('#VanBanLienQuanViewModel_0__SoVanBan').val());
        var ngay = $('#VanBanLienQuanViewModel_0__Ngay').val();
        var noiDung = $('#VanBanLienQuanViewModel_0__NoiDung').val();
        var coQuanId = $('#VanBanLienQuanViewModel_0__CoQuanId').val();

        if (soVanBan == '' || soVanBan == undefined) {
            return false;
        }
        if (ngay == '' || ngay == undefined) {
            return false;
        }
        if (noiDung == '' || noiDung == undefined) {
            return false;
        }
        if (coQuanId == '' || coQuanId == undefined) {
            return false;
        }
        return true;
    };

    resetRowTemplateVanBan = function () {
        $('#VanBanLienQuanViewModel_0__SoVanBan').val('');
        $('#VanBanLienQuanViewModel_0__Ngay').val(formatDate());
        $('#VanBanLienQuanViewModel_0__NoiDung').val('');
        $('#VanBanLienQuanViewModel_0__CoQuanId').val('');

        $('#btnAddVanBanLienQuan').attr('disabled', true);
    }

    resetRowTempalteXuLy = function () {
        $('#QuaTrinhXuLyViewModel_0__NoiDung').val('');
        $('#QuaTrinhXuLyViewModel_0__NhacNho').val(1);//reset default to -- Nhac nho --

        $('#btnAddQuaTrinhXuLy').attr('disabled', true);
    }

    formatDate = function () {
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();

        var output =
            (day < 10 ? '0' : '') + day + '/' +
            (month < 10 ? '0' : '') + month + '/' +
            +d.getFullYear();

        return output;
    }

    getMinutes = function () {
        var d = new Date();
        var m = d.getMinutes();

        var output = (m < 10 ? '0' : '') + m;

        return output;
    }

    getHours = function () {
        var d = new Date();
        var h = d.getHours();
        var output = (h < 10 ? '0' : '') + h;

        return output;
    }
    /*End Add, Edit, Delete row*/

    $('#UsersPhoiHopId').multiselect({
        includeSelectAllOption: true
    });
});