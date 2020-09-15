$(document).ready(function () {
    Inicializa_Modal()
});

function Inicializa_Modal() {
    $('.lnk-modal').click(function (event) {
        var id = $(this).data("modal")
        $(id).modal();
    });
}