using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunmei.XPM.Data
{
    public class RolePurviewInfo
    {
        public int RoleId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public RoleAuthorization Authorization { get; set; }
    }
}
