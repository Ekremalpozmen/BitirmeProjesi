using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
