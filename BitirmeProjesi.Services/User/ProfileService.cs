using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.Common;
using BitirmeProjesi.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.User
{
    public class ProfileService
    {
        private readonly BitirmeProjesiEntities _context;
        public ProfileService(BitirmeProjesiEntities context)
        {
            _context = context;
        }
        public UserModel GetProfile(int userId)
        {
            var userProfile = _context.Users.FirstOrDefault(x => x.Id == userId);
            var profile = new UserModel()
            {
                Id = userId,
                Name = userProfile.Name,
                SurName = userProfile.SurName,
                Email = userProfile.Email,
                Gender = (bool)userProfile.Gender,
                UserName = userProfile.UserName,
            };

            return profile;
        }

        public async Task<UserModel> GetEditProfileViewModelAsync(int userId)
        {
            var profile = await (from b in _context.Users
                                 where b.Id == userId
                                 select new UserModel()
                                 {
                                     Id = userId,
                                     Name = b.Name,
                                     SurName = b.SurName,
                                     Email = b.Email,
                                     UserName = b.UserName,
                                 }).FirstOrDefaultAsync();
            return profile;
        }


        public ServiceCallResult EditProfile(UserModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var profile = _context.Users.FirstOrDefault(x => x.Id == model.Id);

            profile.Name = model.Name;
            profile.SurName = model.SurName;
            profile.Email = model.Email;
            profile.UserName = model.UserName;

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.SuccessMessages.Add("Düzenlendi");
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
