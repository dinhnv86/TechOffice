/// <reference path="../jquery-1.12.4.js" />
$(document).ready(function () {

    /*BEGIN DATE PICKER*/
    var optionCalendar = {
        autoSize: true,
        constrainInput: true,
        dateFormat: 'dd/mm/yy',
        minDate: new Date(),
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
    /*END DATE PICKER*/

    /*BEGIN VAN BAN LIEN QUAN*/
    var suffixVanBan = undefined;
    var listTD = undefined;

    $('.btnDeleteVanBanLienQuan').on('click', function () {
        var row = $(this).closest('tr');
        var idVanBan = row.find('input[type="hidden"]').val();
        $.ajax({
            type: 'POST',
            async: false,
            url: '/congviec/deleteVanBanLienQuan',
            data: {
                vanBanLienQuanId: idVanBan,
            },
            success: function (data) {
                if (data.code == 'SB01')
                    deleteRow(row);
                else
                    alert(message.CongViec_Detail_Delete_VanBanLienQuan);
            }
        }).fail(function () {
            alert(message.CongViec_Detail_Delete_VanBanLienQuan);
        });
    });

    $('.btnEditVanBanLienQuan').on('click', function () {
        var tds = $(this).closest('tr').find('td');
        //var id = tds.eq(0).find('input[type="hidden"]').attr('id');
        //suffixVanBan = id.match(/\d+/);

        $('#txtSoVanBan').val(tds.eq(0).find('input[type="hidden"]').val());
        $('#txtVanBanLienQuanNgay').val(tds.eq(1).find('input[type="hidden"]').val().substr(0, 11));
        $('#txtVanBanLienQuanNoiDung').val(tds.eq(2).find('input[type="hidden"]').val());
        $('#CoQuanIdTemp').val(tds.eq(3).find('input[type="hidden"]').val());

        listTD = tds;
    });

    $('#btnSaveVanBanLienQuan').on('click', function () {
        if (editRowVanBan()) {
            listTD = undefined;
            resetRowTemplateVanBan();
        }
    });

    editRowVanBan = function () {
        var prefix = "VanBanLienQuanViewModel_";
        $('#txtSoVanBan').val();

        if (listTD != undefined) {
            var soVanBan = $('#txtSoVanBan').val();
            listTD.eq(0).find('input[type="hidden"]').val(soVanBan);
            listTD.eq(0).find('span').text(soVanBan);

            var ngay = $('#txtVanBanLienQuanNgay').val();
            listTD.eq(1).find('input[type="hidden"]').val(ngay);
            listTD.eq(1).find('span').text(ngay);

            var noiDung = $('#txtVanBanLienQuanNoiDung').val();
            listTD.eq(2).find('input[type="hidden"]').val(noiDung);
            listTD.eq(2).find('span').text(noiDung);

            listTD.eq(3).find('input[type="hidden"]').val($('#CoQuanIdTemp').val());
            var nameCoQuan = $('#CoQuanIdTemp option:selected').text();
            listTD.eq(3).find('span').text(nameCoQuan);

            return true;
        }
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
    /*END VAN BAN LIEN QUAN*/

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

    /*dropdown list multiple select*/
    $('#UsersPhoiHopId').multiselect({
        includeSelectAllOption: true
    });
    /*end*/
});