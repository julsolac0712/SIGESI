$(function () {
    InicializaDatepicker()
});

function InicializaDatepicker() {
    $(".date-picker").datepicker(
        $.extend({
            dateFormat: "yyyy-mm-dd",
            changeMonth: true,
            changeYear: true
        }, $.datepicker.regional["es"]));

    $(".date-picker-en").datepicker(
        $.extend({
            dateFormat: "yyyy-mm-dd",
            changeMonth: true,
            changeYear: true
        }, $.datepicker.regional[""]));
    //Pongo el valor de los datepicker.
    //$(".date-picker, .date-picker-en").each(function () {
    //    $(this).datepicker('setDate', new Date($(this).val()));
    //});
}