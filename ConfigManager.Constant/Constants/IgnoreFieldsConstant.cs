namespace ConfigManager.Constant.Constants
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IgnoreFieldsConstant.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：忽略键的常量
    /// 创建标识：yjq 2017/8/6 21:45:37
    /// </summary>
    public class IgnoreFieldsConstant
    {
        /// <summary>
        /// fid
        /// </summary>
        public static readonly string[] Ignore_FID = new string[1] { "FID" };

        /// <summary>
        /// FID和创建信息
        /// </summary>
        public static readonly string[] Ignore_KeyAndCreate = new string[] { "FID", "FCreateTime", "FCreateUserID" };
    }
}