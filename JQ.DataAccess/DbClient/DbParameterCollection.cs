﻿using JQ.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JQ.DataAccess.DbClient
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DbQueryParameterCollection.cs
    /// 类属性：局部类（非静态）
    /// 类功能描述：DbParameter集合
    /// 创建标识：yjq 2017/7/13 13:43:59
    /// </summary>
    internal sealed class DbParameterCollection : MarshalByRefObject, IDbParameterCollection
    {
        private Dictionary<string, ParameterInfo> _parameters = new Dictionary<string, ParameterInfo>();

        private DynamicParameters _items;

        public DbParameterCollection()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="obj">将对象添加到参数中（不支持数组和ParameterInfo），支持一般对象</param>
        public DbParameterCollection(object obj) : this()
        {
            AddObjectParam(obj);
        }

        /// <summary>
        /// 参数值（用于和数据库交互）
        /// </summary>
        public object ParaItems
        {
            get
            {
                if (_items == null)
                {
                    _items = new DynamicParameters();
                    foreach (var item in _parameters.Values)
                    {
                        _items.Add(item.ParameterName, value: item.Value, dbType: item.DbType, direction: item.ParameterDirection, size: item.Size, scale: item.Scale);
                    }
                }
                return _items;
            }
        }

        /// <summary>
        /// 参数名列表
        /// </summary>
        public IEnumerable<string> ParameterNames => _items.ParameterNames;

        /// <summary>
        /// 获取当前参数信息列表(不用于和数据库交互)
        /// </summary>
        public IEnumerable<ParameterInfo> ParameterList => _parameters.Select(m => m.Value);

        /// <summary>
        /// 将对象添加到参数中（不支持数组和ParameterInfo），支持一般对象
        /// </summary>
        /// <param name="param">对象值</param>
        /// <param name="prefix">参数名字前缀</param>
        public void AddObjectParam(object param, string prefix = null)
        {
            if (param != null)
            {
                var objType = param.GetType();
                if (!objType.IsArray)
                {
                    var parameterInfoList = param.ToDbParam<ParameterInfo>(string.Empty, prefix ?? string.Empty);
                    AddParameter(parameterInfoList);
                }
            }
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParameter(string parameterName, object value)
        {
            AddParameter(new ParameterInfo(parameterName, value, null, null, null, scale: null));
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">数据库类型</param>
        public void AddParameter(string parameterName, object value, DbType? dbType)
        {
            AddParameter(new ParameterInfo(parameterName, value, dbType, null, null, scale: null));
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="size">长度</param>
        public void AddParameter(string parameterName, object value, DbType? dbType, int? size)
        {
            AddParameter(new ParameterInfo(parameterName, value, dbType, size, null, scale: null));
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="size">长度</param>
        /// <param name="direction">Dataset参数类型</param>
        /// <param name="scale">参数值的精度</param>
        public void AddParameter(string parameterName, object value, DbType? dbType, int? size, ParameterDirection? direction, byte? scale = null)
        {
            AddParameter(new ParameterInfo(parameterName, value, dbType, size, direction, scale: scale));
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="info">参数信息</param>
        public void AddParameter(ParameterInfo info)
        {
            if (info != null)
            {
                _parameters[Clean(info.ParameterName)] = info;
                ResetParamItem();
            }
        }

        /// <summary>
        /// 添加参数列表
        /// </summary>
        /// <param name="infoList">参数信息</param>
        public void AddParameter(List<ParameterInfo> infoList)
        {
            if (infoList != null && infoList.Any())
            {
                foreach (var item in infoList)
                {
                    AddParameter(item);
                }
            }
        }

        /// <summary>
        /// 根据名字获取值
        /// </summary>
        /// <typeparam name="T">值得类型</typeparam>
        /// <param name="name">参数名字</param>
        /// <returns></returns>
        public T GetValue<T>(string name)
        {
            return _items.Get<T>(name);
        }

        /// <summary>
        /// 参数重置
        /// </summary>
        private void ResetParamItem()
        {
            _items = null;
        }

        /// <summary>
        /// 清除符号
        /// </summary>
        /// <param name="name">要清除的字符</param>
        /// <returns>清除后的字符</returns>
        private static string Clean(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                switch (name[0])
                {
                    case '@':
                    case ':':
                    case '?':
                        return name.Substring(1);
                }
            }
            return name;
        }
    }
}