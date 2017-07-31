using Castle.DynamicProxy;
using JQ.Result.Operate;
using JQ.Utils;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace JQ.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BizIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：业务AOP
    /// 创建标识：yjq 2017/7/31 14:09:51
    /// </summary>
    public class BizIntercept : BaseIntercept
    {
        /// <summary>
        /// 异步方法处理
        /// </summary>
        private static readonly MethodInfo handleAsyncMethodInfo = typeof(BizIntercept).GetMethod("OperateAsyncFunction", BindingFlags.Instance | BindingFlags.NonPublic);

        public async override Task AsyncAction(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                var task = invocation.ReturnValue as Task;
                await task;
            }
            catch (BizException ex)
            {
                LogUtil.Info(ex.Message);
                invocation.ReturnValue = OperateUtil.EmitCreate(invocation.TargetType, OperateState.ParamError, ex.Message);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: $"{invocation.TargetType.FullName}-{invocation.Method.Name}");
                invocation.ReturnValue = OperateUtil.EmitCreate(invocation.TargetType, OperateState.Failed, "处理失败");
            }
        }

        public override void AsyncFunction(IInvocation invocation)
        {
            invocation.Proceed();
            var resultType = invocation.Method.ReturnType.GetGenericArguments()[0];
            var mi = handleAsyncMethodInfo.MakeGenericMethod(resultType);
            invocation.ReturnValue = mi.Invoke(this, new[] { invocation, invocation.ReturnValue, $"{invocation.TargetType.FullName}-{invocation.Method.Name}" });
        }

        public override void SynchronousAction(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (BizException ex)
            {
                LogUtil.Info(ex.Message);
                invocation.ReturnValue = OperateUtil.EmitCreate(invocation.TargetType, OperateState.ParamError, ex.Message);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: $"{invocation.TargetType.FullName}-{invocation.Method.Name}");
                invocation.ReturnValue = OperateUtil.EmitCreate(invocation.TargetType, OperateState.Failed, "处理失败");
            }
        }

        private async Task<T> OperateAsyncFunction<T>(IInvocation invocation, Task<T> task, string memberName = null) where T : class
        {
            try
            {
                return await task;
            }
            catch (BizException ex)
            {
                LogUtil.Info(ex.Message);
                return OperateUtil.EmitCreate(typeof(T), OperateState.ParamError, ex.Message) as T;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, memberName: memberName);
                return OperateUtil.EmitCreate(invocation.TargetType, OperateState.Failed, "处理失败") as T;
            }
        }
    }
}