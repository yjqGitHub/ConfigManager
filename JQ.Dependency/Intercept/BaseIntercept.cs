using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;

namespace JQ.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BaseIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：基础AOP类
    /// 创建标识：yjq 2017/7/15 14:33:04
    /// </summary>
    public abstract class BaseIntercept : IInterceptor
    {
        /// <summary>
        /// 异步类型(无返回值)
        /// </summary>
        private static readonly Type _AsyncActionType = typeof(Task);

        /// <summary>
        /// 异步方法类型(有返回值)
        /// </summary>
        private static readonly Type _AsyncFunctionType = typeof(Task<>);

        public virtual void Intercept(IInvocation invocation)
        {
            var delegateType = GetDelegateType(invocation);
            if (delegateType == MethodType.Synchronous)
            {
                SynchronousAction(invocation);
            }
            else if (delegateType == MethodType.AsyncAction)
            {
                invocation.ReturnValue = AsyncAction(invocation);
            }
            else
            {
                AsyncFunction(invocation);
            }
        }

        /// <summary>
        /// 异步处理方法
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        public abstract Task AsyncAction(IInvocation invocation);

        /// <summary>
        /// 同步处理方法
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void SynchronousAction(IInvocation invocation);

        /// <summary>
        /// 异步有返回值处理方法
        /// </summary>
        public abstract void AsyncFunction(IInvocation invocation);

        /// <summary>
        /// 获取方法类型
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        private MethodType GetDelegateType(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;
            if (returnType == _AsyncActionType)
                return MethodType.AsyncAction;
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == _AsyncFunctionType)
                return MethodType.AsyncFunction;
            return MethodType.Synchronous;
        }

        /// <summary>
        /// 方法类型
        /// </summary>
        private enum MethodType
        {
            /// <summary>
            /// 同步方法
            /// </summary>
            Synchronous,

            /// <summary>
            /// 异步(无返回值)
            /// </summary>
            AsyncAction,

            /// <summary>
            /// 异步方法(有返回值)
            /// </summary>
            AsyncFunction
        }
    }
}