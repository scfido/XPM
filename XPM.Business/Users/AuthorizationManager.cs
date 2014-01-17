using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunmei.XPM.Business
{
    /// <summary>
    /// 管理用户访问各个模块的授权。
    /// </summary>
    public static class AuthorizationManager
    {
        /// <summary>
        /// 断定一个角色能否访问
        /// </summary>
        /// <param name="roleName">要断定的角色。</param>
        /// <param name="controller">被访问的控制器名称。</param>
        /// <param name="action">被访问的Action名称。</param>
        /// <returns>能访问返回True，否则为False。</returns>
        public static bool CanAccess(string role, string controller, string action)
        {
            return false;
        }

        public static bool CanAccess(string[] roles, string controller, string action)
        {
            return false;
        }
    }
}
