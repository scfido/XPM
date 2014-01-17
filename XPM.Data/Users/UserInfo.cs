using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Xunmei.XPM.Data
{
    /// <summary>
    /// NVS激活信息中包含的摄像信息。
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 设置或获取取摄像机型号。
        /// </summary>
        [Required, MaxLength(32, ErrorMessage = "用户名最大长度为32。")]
        public string UserName { get; set; }

        [MaxLength(64, ErrorMessage = "密码Hash最大长度为32。")]
        public string PasswordHash { get; set; }

        [MaxLength(64, ErrorMessage = "用户名最大长度为32。")]
        public string Salt { get; set; }

        [Required, MaxLength(8,ErrorMessage="真实姓名最大长度为8。")]
        public string RealName { get; set; }

        public bool IsLocked { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastLogin { get; set; }
        public int Visits { get; set; }

        public bool IsDeleted { get; set; }

        public string Departement { get; set; }
    }
}
