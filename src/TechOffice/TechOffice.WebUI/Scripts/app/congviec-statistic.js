/// <reference path="../jquery-1.12.4.js" />
$(document).ready(function () {
    var optionCalendar =
 {
     autoSize: true,
     constrainInput: true,
     dateFormat: 'dd/mm/yy',
     maxDate: new Date(),
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
});