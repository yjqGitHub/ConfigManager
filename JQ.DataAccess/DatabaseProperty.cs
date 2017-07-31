namespace JQ.DataAccess
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DatabaseProperty.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：数据库属性信息
    /// 创建标识：yjq 2017/7/12 21:30:13
    /// </summary>
    public sealed class DatabaseProperty
    {
        private DatabaseConnection _reader;
        private DatabaseConnection _writer;

        public DatabaseConnection Reader
        {
            get { return _reader; }
        }

        public DatabaseConnection Writer
        {
            get { return _writer; }
        }

        public DatabaseProperty(DatabaseConnection reader, DatabaseConnection writer)
        {
            _reader = reader;
            _writer = writer;
        }
    }
}