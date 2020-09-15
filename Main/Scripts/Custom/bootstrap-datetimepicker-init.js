function initializeDatePicker(idioma) {
    if (idioma == 'es') {
        $('.date-picker').datetimepicker({
            format: 'YYYY-MM-DD',
            locale: 'es',
            icons: {
                time: "fa fa-clock-o"
            }
        });
        $('.date-time-picker').datetimepicker({
            locale: 'es',
            icons: {
                time: "fa fa-clock-o"
            }
        });
    } else {
        $('.date-picker').datetimepicker({
            format: 'YYYY-MM-DD',
            icons: {
                time: "fa fa-clock-o"
            }
        });
        $('.date-time-picker').datetimepicker({
            icons: {
                time: "fa fa-clock-o"
            }
        });
    }
    return true;
}