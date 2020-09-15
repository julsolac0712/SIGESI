function initializeFileInput(idioma) {
    $(".file-input-full").fileinput({
        language: idioma,
        showUpload: false
    });
    $(".file-input-np").fileinput({
        language: idioma,
        showPreview: false,
        showUpload: false,
    });
    $(".file-input-small").fileinput({
        language: idioma,
        showCaption: false,
        showPreview: false,
        showUpload: false
    });
}