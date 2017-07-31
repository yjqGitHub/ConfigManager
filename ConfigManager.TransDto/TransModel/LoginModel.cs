using System.ComponentModel.DataAnnotations;

namespace ConfigManager.TransDto.TransModel
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LoginModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：登录Model
    /// 创建标识：yjq 2017/7/31 13:47:05
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Pwd { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "验证码不能为空")]
        public string Code { get; set; }
    }
}