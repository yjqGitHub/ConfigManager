namespace JQ.DataAccess
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DatabaseConnection.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：连接信息
    /// 创建标识：yjq 2017/7/12 19:27:27
    /// </summary>
    public struct DatabaseConnection
    {
        private string _connectionString;
        private DatabaseType _databaseType;

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public DatabaseType DatabaseType
        {
            get
            {
                return _databaseType;
            }
            set
            {
                _databaseType = value;
            }
        }
    }
}