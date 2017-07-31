//Ajax封装
function Ajax(config, successCallBack, failedCallBack) {
    ShowLoading();
    $.ajax(config).done(function (result) {
        if (result.Code == 1) {
            successCallBack && successCallBack(result);
        } else if (result.Code == 1000) {
            ShowWarningMsg("请先登录");
            top.location.href = result.RedirectUrl;
        } else {
            ShowWarningMsg(result.Message);
            failedCallBack && failedCallBack(result);
        }
        HideLoading();
    }).fail(function (err) {
        HideLoading();
        ShowWarningMsg("请求服务失败");
    });
}

