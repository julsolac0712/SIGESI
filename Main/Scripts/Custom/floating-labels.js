$(document).ready(function () {
    //Se ejecuta en la carga del documento para cuando los elementos ya tienen un valor.
    focus_input($(".float-input > *"));
    un_focus_input($(".float-input > *"));

    $(".float-input > *").focus(function () {
        focus_input($(this));
    });
    $(".float-input > *").blur(function () {
        un_focus_input($(this));
    });
});

function focus_input(input) {
    input.addClass('focused');
    input.removeClass('filled');
    input.attr('placeholder', $(this).data("placeholder"));
}

function un_focus_input(input) {
    if (input == null) {
        if (input.val().length == 0) {
            input.removeClass('focused');
            input.removeAttr('placeholder');
        } else {
            input.addClass('filled');
        }
    }
}

