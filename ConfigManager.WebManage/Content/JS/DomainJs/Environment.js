$("#form-edit").submit(function () {
    //alert($("#form-edit").valid());
    if ($(this).valid()) {
        Ajax({
            type: this.method,
            url: this.action,
            data: $(this).serialize()
        }, function (data) {
            RefreshTopFrameAndClose();
        }, function (errorData) {
        });
    }
    return false;
})