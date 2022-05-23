using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.Common;
using BitirmeProjesi.ViewModels.User.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.Vet
{
    public class SecurityService
    {
        private readonly BitirmeProjesiEntities _context;
        public SecurityService(BitirmeProjesiEntities context)
        {
            _context = context;
        }

        public VetUsers Login(LoginViewModel login)
        {
            return _context.VetUsers.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
        }

        public async Task<ServiceCallResult> Register(RegisterViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool userEmail = await _context.VetUsers.AnyAsync(x => x.Email == model.Email || x.UserName == model.UserName);

            if (userEmail)
            {
                callResult.ErrorMessages.Add("E-mail veya Kullanıcı Adı kullanımda");
                return callResult;
            }

            var vetuser = new VetUsers()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
            };
            _context.VetUsers.Add(vetuser);
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbTransaction.Commit();
                    callResult.SuccessMessages.Add("Kullanıcı Kayıt Edildi");
                    callResult.Success = true;
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }

        }

    }
}
