namespace ConfigManager.TransDto.QueryWhereDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BasePageQueryDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：分页查询基础传输对象
    /// 创建标识：yjq 2017/8/8 15:21:35
    /// </summary>
    public class BasePageQueryDto
    {
        protected int? _pageIndex;
        protected int? _pageSize;
        protected string _orderColumn;

        /// <summary>
        /// 当前页面Id
        /// </summary>
        public virtual int PageIndex
        {
            get
            {
                if (_pageIndex == null || _pageIndex <= 0)
                {
                    return 1;
                }
                return _pageIndex ?? 1;
            }
            set
            {
                _pageIndex = value;
            }
        }

        /// <summary>
        /// 页长
        /// </summary>
        public virtual int PageSize
        {
            get
            {
                if (_pageSize == null || _pageSize <= 0)
                {
                    return 30;
                }
                if (_pageSize.Value > 300)
                {
                    return 30;
                }
                return _pageSize ?? 30;
            }
            set
            {
                _pageSize = value;
            }
        }

        /// <summary>
        /// 排列字段
        /// </summary>
        public virtual string OrderColumn
        {
            get
            {
                return _orderColumn;
            }
            set { _orderColumn = value; }
        }
    }
}