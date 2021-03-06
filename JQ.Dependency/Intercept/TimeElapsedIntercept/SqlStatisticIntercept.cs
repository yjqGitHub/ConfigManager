﻿namespace JQ.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：SqlStatisticIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Sql统计AOP
    /// 创建标识：yjq 2017/7/22 15:12:57
    /// </summary>
    public class SqlStatisticIntercept : BaseMonitorIntercept
    {
        public SqlStatisticIntercept(TimeElapsedStatistic timeElapsedStatistic) : base(timeElapsedStatistic)
        {
        }

        public override TimeElapsedType TimeElapsedType
        {
            get
            {
                return TimeElapsedType.Sql;
            }
        }
    }
}