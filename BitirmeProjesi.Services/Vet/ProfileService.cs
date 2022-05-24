using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.Common;
using BitirmeProjesi.ViewModels.User;
using BitirmeProjesi.ViewModels.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BitirmeProjesi.ViewModels.Vet.VetModel;

namespace BitirmeProjesi.Services.Vet
{
    public class ProfileService
    {
        private readonly BitirmeProjesiEntities _context;
        public ProfileService(BitirmeProjesiEntities context)
        {
            _context = context;
        }

        public VetModel GetProfile(int userId)
        {
            var userProfile = _context.VetUsers.FirstOrDefault(x => x.Id == userId);
            var profile = new VetModel()
            {
                Id = userId,
                Name = userProfile.Name,
                SurName = userProfile.SurName,
                Email = userProfile.Email,
                Gender = (bool)userProfile.Gender,
                UserName = userProfile.UserName,
                Expertise = userProfile.Expertise,
                GraduationDate = userProfile.GraduationDate,
                PhoneNumber = userProfile.PhoneNumber,
                University = userProfile.University,
                WorkShopName = userProfile.WorkShopName,
            };
            return profile;
        }
        public ServiceCallResult EditPassword(EditPassword model, UserModel vet)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var currentVet = _context.VetUsers.FirstOrDefault(x => x.Id == vet.Id);

            var userPassword = currentVet.Password;

            if (userPassword == model.OldPassword)
            {
                if (model.NewPassword == model.NewPasswordAgain)
                {
                    currentVet.Password = model.NewPassword;
                }
                else
                {
                    callResult.ErrorMessages.Add("Şifreler Uyuşmuyor");
                    return callResult;
                }
            }
            else
            {
                callResult.ErrorMessages.Add("Eski Şifre Yanlış");
                return callResult;
            }

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.SuccessMessages.Add("Şifre Değiştirildi");
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
