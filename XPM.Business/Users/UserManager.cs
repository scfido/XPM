using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunmei.XPM.Data;
using Xunmei.XPM.Data.Provider;

namespace Xunmei.XPM.Business
{
    public class UserManager : IDisposable
    {
        private  XPMDbContext dbProvider;

        public UserManager()
        {
            dbProvider = new XPMDbContext();
        }

        public async Task<UserInfo> FindAsync(string userName, string password)
        {
            using (var dbProvider = new XPMDbContext())
            {
                UserInfo user = await dbProvider.Users.FirstAsync(u => u.UserName == userName);
                if (user == null)
                    return null;
               
                string passwordHash = GetHash(password, user.Salt);
                if (passwordHash == user.PasswordHash)
                    return user;
                else
                    return null;
            }
        }

        public string Create(UserInfo user, string password)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (dbProvider != null)
            {
                dbProvider.Dispose();
                dbProvider = null;
            }
        }

        private string GetHash(string password, string salt)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] buffer = Encoding.UTF8.GetBytes(password + salt);
            byte[] result = sha.ComputeHash(buffer);
            string hash = Convert.ToBase64String(result);
            
            return hash;
        }
    }
}
