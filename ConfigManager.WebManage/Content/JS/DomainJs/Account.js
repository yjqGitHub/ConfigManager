//切换验证码
function ToggleCode(obj, codeurl) {
    $("#Code").val("");
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}

//表单提交
$("form").submit(function () {
    if (JudgeValidate("form")) {
        Ajax({
            url: "/Account/Login",
            type: "POST",
            data: $(this).serialize()
        }, function (data) {
            ShowSuccessMsg(data.Message || "登录成功");
            location.href = "/Home/Index";
        }, function (error) {
            $("#Code").focus();
            $("#ValidateCode_Img").click();
        });
    }
    return false;
})