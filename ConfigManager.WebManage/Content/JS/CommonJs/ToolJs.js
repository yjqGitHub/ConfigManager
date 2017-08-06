//Ajax封装
function Ajax(config, successCallBack, failedCallBack) {
    ShowLoading();
    $.ajax(config).done(function (result) {
        if (result.Code == 1) {
            successCallBack && successCallBack(result);
        } else if (result.Code == 1000) {
            if (window != top) {
                top.ShowWarningMsg("请先登录");
            } else {
                ShowWarningMsg("请先登录");
            }
            top.location.href = result.RedirectUrl;
        } else {
            if (result.Message && result.Message.trim() != "") {
                ShowWarningMsg(result.Message);
            }
            failedCallBack && failedCallBack(result);
        }
        HideLoading();
    }).fail(function (err) {
        HideLoading();
        if (window != top) {
            top.ShowWarningMsg("请求服务失败");
        } else {
            ShowWarningMsg("请求服务失败");
        }
    });
}