$("#form-edit").submit(function () {
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