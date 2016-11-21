/// <reference path="../jquery-1.12.4.js" />
$(document).ready(function () {

    /*BEGIN DATE PICKER*/

    $('#txtVanBanLienQuanNgay').removeClass('control-datepicker');

    var optionCalendarDefault =
    {
        autoSize: true,
        constrainInput: true,
        dateFormat: 'dd/mm/yy',
    };

    var optionCalendar = optionCalendarDefault;
    optionCalendar.minDate = new Date();

    $('.control-datepicker').datepicker(optionCalendar);
    $('#txtVanBanLienQuanNgay').datepicker(optionCalendarDefault);

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
    /*END DATE PICKER*/

    /*BEGIN VAN BAN LIEN QUAN*/
    var suffixVanBan = undefined;
    var rowEditingVanBan = undefined;

    $('.btnDeleteVanBanLienQuan').on('click', function () {
        var row = $(this).closest('tr');
        var idVanBan = row.find('input[type="hidden"]').val();
        if (idVanBan != null && idVanBan != undefined) {
            //Delete row at server
            $.ajax({
                type: 'POST',
                async: false,
                url: '/congviec/deleteVanBanLienQuan',
                data: {
                    vanBanLienQuanId: idVanBan,
                },
                success: function (data) {
                    if (data.code == 'SB01')
                        resetRowNumber(row);
                    else
                        alert(message.CongViec_Detail_Delete_VanBanLienQuan);
                }
            }).fail(function () {
                alert(message.CongViec_Detail_Delete_VanBanLienQuan);
            });
        }
        else {
            //Delete row at client
            deleteRowVanBanAtClient(row);
        }
    });

    $('.btnEditVanBanLienQuan').on('click', function () {
        var tds = $(this).closest('tr').find('td');
        //var id = tds.eq(0).find('input[type="hidden"]').attr('id');
        //suffixVanBan = id.match(/\d+/);

        $('#txtSoVanBan').val(tds.eq(0).find('input[type="hidden"]').val());
        $('#txtVanBanLienQuanNgay').val(tds.eq(1).find('input[type="hidden"]').val().substr(0, 11));
        $('#txtVanBanLienQuanNoiDung').val(tds.eq(2).find('input[type="hidden"]').val());
        $('#CoQuanIdTemp').val(tds.eq(3).find('input[type="hidden"]').val());

        rowEditingVanBan = tds;
    });

    $('#btnSaveVanBanLienQuan').on('click', function () {
        var idVanBan = $(rowEditingVanBan).find('input[type="hidden"]').val();
        var saveResult = false;
        if (rowEditingVanBan != undefined) {
            if (idVanBan != null && idVanBan != undefined) {
                //case edit row at server
                saveResult = editRowVanBanAtServer();
            }
                //case edit row at client
            else {
                saveResult = editRowVanBanAtClient();
            }
        }
        else {
            addRowVanBanAtClient();
        }
        if (saveResult) {
            rowEditingVanBan = undefined;
            resetRowTemplateVanBan();
        }
    });

    editRowVanBanAtServer = function () {
        //Case edit row at client
        var soVanBan = $('#txtSoVanBan').val();
        rowEditingVanBan.eq(0).find('input[type="hidden"]').val(soVanBan);
        rowEditingVanBan.eq(0).find('span').text(soVanBan);

        var ngay = $('#txtVanBanLienQuanNgay').val();
        rowEditingVanBan.eq(1).find('input[type="hidden"]').val(ngay);
        rowEditingVanBan.eq(1).find('span').text(ngay);

        var noiDung = $('#txtVanBanLienQuanNoiDung').val();
        rowEditingVanBan.eq(2).find('input[type="hidden"]').val(noiDung);
        rowEditingVanBan.eq(2).find('span').text(noiDung);

        rowEditingVanBan.eq(3).find('input[type="hidden"]').val($('#CoQuanIdTemp').val());
        var nameCoQuan = $('#CoQuanIdTemp option:selected').text();
        rowEditingVanBan.eq(3).find('span').text(nameCoQuan);

        return true;
    };

    editRowVanBanAtClient = function () {

        var getValues = getValuesTemplateVanBan();

        $(rowEditingVanBan).eq(0).each(function () {
            $(this).find("input[type='hidden']").val(getValues.soVanBan);
            $(this).find('span').text(soVanBan);
        });

        $(rowEditingVanBan).eq(1).each(function () {
            $(this).find("input[type='hidden']").val(getValues.ngay);
            $(this).find('span').text(ngay);
        });

        $(rowEditingVanBan).eq(2).each(function () {
            $(this).find('input[type="hidden"]').val(getValues.noiDung);
            $(this).find('span').text(noiDung);
        });

        $(rowEditingVanBan).eq(3).each(function () {
            $(this).find('input[type="hidden"]').val(getValues.coQuanId);
            $(this).find('span').text(getValues.nameCoQuan);
        });

        return true;
    };

    deleteRowVanBanAtClient = function (rowDeleted) {
        resetRowNumber(rowDeleted);
    };

    addRowVanBanAtClient = function () {
        var values = getValuesTemplateVanBan();
        var tbody = $('#tbodyEditVanBan > tr');
        var tbody_len = (tbody.length) - 1;
        var prefix = "VanBanLienQuanViewModel";
        var template = ('<tr>' +
        '<td>' + '<input id="' + prefix + '_' + tbody_len + '__SoVanBan" name="' + prefix + '[' + tbody_len + '].SoVanBan" type="hidden" value="' + values.soVanBan + '">' + '<span>' + values.soVanBan + '</span>' + '</td>'
        + '<td>' + '<input id="' + prefix + '_' + tbody_len + '__Ngay" name="' + prefix + '[' + tbody_len + '].Ngay" type="hidden" value="' + values.ngay + '">' + '<span>' + values.ngay + '</span>' + '</td>'
        + '<td>' + '<input id="' + prefix + '_' + tbody_len + '__NoiDung" name="' + prefix + '[' + tbody_len + '].NoiDung" type="hidden" value="' + values.noiDung + '">' + '<span>' + values.noiDung + '</span>' + '</td>'
        + '<td>' + '<input id="' + prefix + '_' + tbody_len + '__CoQuanId" name="' + prefix + '[' + tbody_len + '].CoQuanId" type="hidden" value="' + values.coQuanId + '">' + '<span>' + values.nameCoQuan + '</span>' + '</td>'
        + '<td>' + '<input type="button" value="Xóa" class="btn btn-link btnDeleteVanBanLienQuan" id="btnDeleteTemp_' + tbody_len + '"/>|' +
                    '<input type="button" value="Sửa" class="btn btn-link btnEditVanBanLienQuan" id="btnEditTemp_' + tbody_len + '"/>' + '</td>'
        + '</tr>');

        var row = $('table#tableAddVanBan > tbody > tr:last').before(template);

        resetRowTemplateVanBan();
    };

    $('#txtSoVanBan, #txtVanBanLienQuanNgay, #txtVanBanLienQuanNoiDung').keyup(function () {
        if (validateValueVanBan())
            $('#btnSaveVanBanLienQuan').attr('disabled', false);
        else
            $('#btnSaveVanBanLienQuan').attr('disabled', true);
    });

    $('#CoQuanIdTemp, #txtVanBanLienQuanNgay').on('change', function () {
        if (validateValueVanBan())
            $('#btnSaveVanBanLienQuan').attr('disabled', false);
        else
            $('#btnSaveVanBanLienQuan').attr('disabled', true);
    });

    validateValueVanBan = function () {
        var soVanBan = ($('#txtSoVanBan').val());
        var ngay = $('#txtVanBanLienQuanNgay').val();
        var noiDung = $('#txtVanBanLienQuanNoiDung').val();
        var coQuanId = $('#CoQuanIdTemp').val();

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
        $('#txtSoVanBan').val('');
        $('#txtVanBanLienQuanNgay').val('');
        $('#txtVanBanLienQuanNoiDung').val('');
        $('#CoQuanIdTemp').val('');

        $('#btnSaveVanBanLienQuan').attr('disabled', true);
    };

    function resetRowNumber(rowDeleted) {
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

    getValuesTemplateVanBan = function () {
        var soVanBan = $('#txtSoVanBan').val();
        var ngay = $('#txtVanBanLienQuanNgay').val();
        var noiDung = $('#txtVanBanLienQuanNoiDung').val();
        var coQuanId = $('#CoQuanIdTemp').val();
        var nameCoQuan = $('#CoQuanIdTemp option:selected').text();

        return {
            soVanBan: soVanBan,
            ngay: ngay,
            noiDung: noiDung,
            coQuanId: coQuanId,
            nameCoQuan: nameCoQuan,
        };
    };
    /*END VAN BAN LIEN QUAN*/

    /*dropdown list multiple select*/
    $('#UsersPhoiHopId').multiselect({
        includeSelectAllOption: true
    });
    /*end*/

    /*BEGIN SUBMIT FORM*/
    onDetailBegin = function () {
        onShowLoading();
    };
    onDetaiComplete = function () {
        onHideLoading()
    };
    onDetaiSuccess = function () {
        window.location.href = '/congviec';
    };
    onDetaiFailure = function () { };
    /*END SUBMIT FORM*/
});