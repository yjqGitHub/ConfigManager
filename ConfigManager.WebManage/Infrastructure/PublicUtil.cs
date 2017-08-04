using JQ.Web;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq ��Ȩ���С�
    /// ������PublicUtil.cs
    /// �����ԣ������ࣨ�Ǿ�̬��
    /// �๦��������PublicUtil
    /// ������ʶ��yjq 2017/7/31 22:03:01
    /// </summary>
    public static class PublicUtil
    {
        #region ��ǰ����Ա

        /// <summary>
        /// ��ǰ�û���CookieKey
        /// </summary>
        private const string _CURRENT_ADMIN_COOKIE_KEY = "Admin";

        /// <summary>
        /// �û�ǩ����ֵ TODO ��̬����
        /// </summary>
        private const string _CURRENT_ADMIN_SIGN_SALT = "7758258";

        /// <summary>
        /// ���õ�ǰ����Ա
        /// </summary>
        /// <param name="adminID">�û�ID</param>
        public static void SetCurrentAdmin(int adminID)
        {
            WebTool.SetCurrentAdmin(adminID, _CURRENT_ADMIN_COOKIE_KEY, _CURRENT_ADMIN_SIGN_SALT);
        }

        /// <summary>
        /// ��ȡ��ǰ����ԱID
        /// </summary>
        /// <returns>С�ڵ���0��ʾδ��¼</returns>
        public static int GetCurrentAdminID()
        {
            return WebTool.GetCurrentAdminID(_CURRENT_ADMIN_COOKIE_KEY, _CURRENT_ADMIN_SIGN_SALT);
        }

        #endregion ��ǰ����Ա
    }
}