CKEDITOR.on('instanceReady', function () {
    $.each(CKEDITOR.instances, function (instance) {
        CKEDITOR.instances[instance].on("change",
            function (e) {
                for (instance in CKEDITOR.instances)
                    CKEDITOR.instances[instance].updateElement();
            });
    });
});