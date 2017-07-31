using JQ.Extensions;
using System.Threading.Tasks;

namespace JQ.Redis.Serialization
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisJsonBinarySerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：json序列化
    /// 创建标识：yjq 2017/7/15 15:29:52
    /// </summary>
    internal class RedisJsonBinarySerializer : IRedisBinarySerializer
    {
        public RedisJsonBinarySerializer()
        {
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字节数组</param>
        /// <returns>对象</returns>
        public virtual T Deserialize<T>(byte[] serializedObject)
        {
            var jsonValue = serializedObject.ToStr();
            return jsonValue.ToObjInfo<T>();
        }

        /// <summary>
        /// 异步反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字节数组</param>
        /// <returns>对象</returns>
        public virtual Task<T> DeserializeAsync<T>(byte[] serializedObject)
        {
            return Task.FromResult(Deserialize<T>(serializedObject));
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字节数组</returns>
        public virtual byte[] Serialize<T>(T item)
        {
            var jsonValue = item.ToJson();
            return jsonValue.ToBytes();
        }

        /// <summary>
        /// 异步序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字节数组</returns>
        public virtual Task<byte[]> SerializeAsync<T>(T item)
        {
            return Task.FromResult(Serialize(item));
        }
    }
}