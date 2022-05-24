using BitirmeProjesi.Data;
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
        //public UserModel GetProfile(int userId)
        //{
        //    var userProfile = _context.Users.FirstOrDefault(x => x.Id == userId);
        //    var profile = new UserModel()
        //    {
        //        Id = userId,
        //        Name = userProfile.Name,
        //        SurName = userProfile.SurName,
        //        Email = userProfile.Email,
        //        Gender = (bool)userProfile.Gender,
        //        UserName = userProfile.UserName,
        //    };

        //    return profile;
        //}
    }
}
