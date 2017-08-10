﻿using JQ.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TypeUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：类型工具
    /// 创建标识：yjq 2017/7/12 18:37:11
    /// </summary>
    public static class TypeUtil
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, FieldInfo[]> _typeFieldCache = new ConcurrentDictionary<RuntimeTypeHandle, FieldInfo[]>();
        private static Dictionary<RuntimeTypeHandle, DbType> _TypeMap;
        public static readonly Type[] BaseTypes;
        public static readonly Type _IntType = typeof(int);
        public static readonly Type _NullableIntType = typeof(int);
        public static readonly Type _StringType = typeof(string);
        public static readonly Type _ObjectType = typeof(object);
        public static readonly Type _NullableGenericType = typeof(Nullable<>);
        public static readonly Type _DbTypeType = typeof(DbType);

        static TypeUtil()
        {
            #region TypeMap

            _TypeMap = new Dictionary<RuntimeTypeHandle, DbType>();
            _TypeMap.Add(typeof(byte).TypeHandle, DbType.Byte);
            _TypeMap.Add(typeof(sbyte).TypeHandle, DbType.SByte);
            _TypeMap.Add(typeof(short).TypeHandle, DbType.Int16);
            _TypeMap.Add(typeof(ushort).TypeHandle, DbType.UInt16);
            _TypeMap.Add(typeof(int).TypeHandle, DbType.Int32);
            _TypeMap.Add(typeof(uint).TypeHandle, DbType.UInt32);
            _TypeMap.Add(typeof(long).TypeHandle, DbType.Int64);
            _TypeMap.Add(typeof(ulong).TypeHandle, DbType.UInt64);
            _TypeMap.Add(typeof(float).TypeHandle, DbType.Single);
            _TypeMap.Add(typeof(double).TypeHandle, DbType.Double);
            _TypeMap.Add(typeof(decimal).TypeHandle, DbType.Decimal);
            _TypeMap.Add(typeof(bool).TypeHandle, DbType.Boolean);
            _TypeMap.Add(typeof(string).TypeHandle, DbType.String);
            _TypeMap.Add(typeof(char).TypeHandle, DbType.StringFixedLength);
            _TypeMap.Add(typeof(Guid).TypeHandle, DbType.Guid);
            _TypeMap.Add(typeof(DateTime).TypeHandle, DbType.DateTime);
            _TypeMap.Add(typeof(DateTimeOffset).TypeHandle, DbType.DateTimeOffset);
            _TypeMap.Add(typeof(TimeSpan).TypeHandle, DbType.Time);
            _TypeMap.Add(typeof(byte[]).TypeHandle, DbType.Binary);
            _TypeMap.Add(typeof(sbyte?).TypeHandle, DbType.SByte);
            _TypeMap.Add(typeof(short?).TypeHandle, DbType.Int16);
            _TypeMap.Add(typeof(ushort?).TypeHandle, DbType.UInt16);
            _TypeMap.Add(typeof(int?).TypeHandle, DbType.Int32);
            _TypeMap.Add(typeof(uint?).TypeHandle, DbType.Int32);
            _TypeMap.Add(typeof(long?).TypeHandle, DbType.Int64);
            _TypeMap.Add(typeof(ulong?).TypeHandle, DbType.Int64);
            _TypeMap.Add(typeof(float?).TypeHandle, DbType.Single);
            _TypeMap.Add(typeof(double?).TypeHandle, DbType.Double);
            _TypeMap.Add(typeof(decimal?).TypeHandle, DbType.Decimal);
            _TypeMap.Add(typeof(bool?).TypeHandle, DbType.Boolean);
            _TypeMap.Add(typeof(char?).TypeHandle, DbType.StringFixedLength);
            _TypeMap.Add(typeof(Guid?).TypeHandle, DbType.Guid);
            _TypeMap.Add(typeof(DateTime?).TypeHandle, DbType.DateTime);
            _TypeMap.Add(typeof(DateTimeOffset?).TypeHandle, DbType.DateTimeOffset);
            _TypeMap.Add(typeof(TimeSpan?).TypeHandle, DbType.Time);
            _TypeMap.Add(typeof(object).TypeHandle, DbType.Object);

            #endregion TypeMap

            #region BaseTypes

            BaseTypes = new Type[] {
                          typeof(byte) ,
                          typeof(sbyte),
                          typeof(short),
                          typeof(ushort),
                          typeof(int),
                          typeof(uint),
                          typeof(long),
                          typeof(ulong),
                          typeof(float),
                          typeof(double),
                          typeof(decimal),
                          typeof(bool),
                          typeof(string),
                          typeof(char),
                          typeof(Guid),
                          typeof(DateTime),
                          typeof(DateTimeOffset),
                          typeof(TimeSpan),
                          typeof(byte[]),
                          typeof(byte?),
                          typeof(sbyte?),
                          typeof(short?),
                          typeof(ushort?),
                          typeof(int?),
                          typeof(uint?),
                          typeof(long?),
                          typeof(ulong?),
                          typeof(float?),
                          typeof(double?),
                          typeof(decimal?),
                          typeof(bool?),
                          typeof(char?),
                          typeof(Guid?),
                          typeof(DateTime?),
                          typeof(DateTimeOffset?),
                          typeof(TimeSpan?),
                          typeof(object) };

            #endregion BaseTypes
        }

        /// <summary>
        /// 根据类型获取字段属性与数据的访问权
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>字段属性与数据的访问权</returns>
        public static FieldInfo[] GetTypeFields(Type type)
        {
            if (type == null) return new FieldInfo[0];

            var typeHandle = type.TypeHandle;
            return _typeFieldCache.GetValue(typeHandle, () =>
            {
                return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            });
        }

        #region 根据类型对应类型获取对应数据库对应的类型

        /// <summary>
        /// 根据类型对应类型获取对应数据库对应的类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>数据库对应的类型</returns>
        public static DbType Type2DbType(Type type)
        {
            if (type.IsEnum || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && type.GetGenericArguments()[0].IsEnum))
            {
                return _TypeMap[typeof(int).TypeHandle];
            }
            if (_TypeMap.ContainsKey(type.TypeHandle))
            {
                return _TypeMap[type.TypeHandle];
            }
            else
            {
                return DbType.Object;
            }
        }

        #endregion 根据类型对应类型获取对应数据库对应的类型

        /// <summary>
        /// 判断类型是否为集合或者数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsArrayOrCollection(this Type type)
        {
            if (type == null) return false;
            return type.IsArray || type.IsGenericType;
        }

        /// <summary>
        /// 获取真实的类型
        /// </summary>
        /// <param name="type">要获取的类型</param>
        /// <returns>真实的类型</returns>
        public static Type GetTrueType(this Type type)
        {
            Type trueType = null;
            if (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    trueType = type.GetGenericArguments()[0];
                }
                else
                {
                    trueType = type;
                }
            }
            return trueType;
        }
    }
}