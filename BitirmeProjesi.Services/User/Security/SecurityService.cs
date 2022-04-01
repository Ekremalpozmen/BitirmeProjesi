using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.User.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.User.Security
{
    public class SecurityService
    {
        private readonly BitirmeProjesiEntities _context;
        public SecurityService(BitirmeProjesiEntities context)
        {
            _context = context;
        }

        public Users Login(LoginViewModel login)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
        }
    }
}
