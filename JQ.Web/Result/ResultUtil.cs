using JQ.Result.Operate;

namespace JQ.Web.Result
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ResultUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：结果工具类
    /// 创建标识：yjq 2017/7/31 13:42:52
    /// </summary>
    public static class ResultUtil
    {
        /// <summary>
        /// 未登录
        /// </summary>
        /// <param name="redirectUrl">跳转地址</param>
        /// <returns>Json返回类</returns>
        public static JQJsonResult NoLogin(string redirectUrl = null)
        {
            return new JQJsonResult { Data = AjaxResult.NoLogin(redirectUrl ?? "/Account/Login") };
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="msg">错误内容</param>
        /// <returns>Json返回类</returns>
        public static JQJsonResult Failed(string msg)
        {
            return new JQJsonResult { Data = AjaxResult.Failed(msg) };
        }

        /// <summary>
        /// 请求成功
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="data">结果</param>
        /// <returns>Json返回类</returns>
        public static JQJsonResult Success(object data, string msg)
        {
            return new JQJsonResult { Data = AjaxResult.Success(data, msg) };
        }

        /// <summary>
        /// 将操作结果转为Json返回类
        /// </summary>
        /// <param name="operateResult">操作结果</param>
        /// <returns>Json返回类</returns>
        public static JQJsonResult ToJsonResult(this OperateResult operateResult)
        {
            return new JQJsonResult(data: operateResult.ToAjaxResult());
        }

        /// <summary>
        /// 将操作结果转为Json返回类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operateResult">操作结果</param>
        /// <returns>Json返回类</returns>
        public static JQJsonResult ToJsonResult<T>(this OperateResult<T> operateResult)
        {
            return new JQJsonResult(data: operateResult.ToAjaxResult());
        }

        /// <summary>
        /// 将操作结果转为AJAX结果
        /// </summary>
        /// <typeparam name="T">返回结果类型</typeparam>
        /// <param name="operateResult">操作结果</param>
        /// <returns>AJAX结果</returns>
        private static AjaxResult ToAjaxResult<T>(this OperateResult<T> operateResult)
        {
            return new AjaxResult(ToAjaxState(operateResult), operateResult.Message, operateResult.Value);
        }

        /// <summary>
        /// 将操作结果转为AJAX结果
        /// </summary>
        /// <param name="operateResult">操作结果</param>
        /// <returns>AJAX结果</returns>
        private static AjaxResult ToAjaxResult(this OperateResult operateResult)
        {
            return new AjaxResult(ToAjaxState(operateResult), operateResult.Message);
        }

        /// <summary>
        /// 将操作结果状态转为Ajax状态
        /// </summary>
        /// <param name="state">操作结果状态</param>
        /// <returns>Ajax状态</returns>
        private static AjaxState ToAjaxState(OperateResult operateResult)
        {
            if (operateResult == null) return AjaxState.Failed;
            switch (operateResult.State)
            {
                case OperateState.Success:
                    return AjaxState.Success;

                case OperateState.ParamError:
                    return AjaxState.Failed;

                case OperateState.Failed:
                    return AjaxState.Failed;

                default:
                    return AjaxState.Failed;
            }
        }
    }
}