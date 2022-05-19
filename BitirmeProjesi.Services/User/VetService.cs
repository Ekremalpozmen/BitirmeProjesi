using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.User
{
    public class VetService
    {
        private readonly BitirmeProjesiEntities _context;
        public VetService(BitirmeProjesiEntities context)
        {
            _context = context;
        }

        public async Task<List<VetListViewModel>> GetVetListViewModel()
        {
            var vetList = await (from b in _context.VetUsers
                                 select new VetListViewModel()
                                 {
                                     Id = (int)b.Id,
                                     Name = b.Name,
                                     Surname = b.SurName,
                                     Email = b.Email,
                                     Expertise = b.Expertise,
                                     Gender = b.Gender,
                                     GraduationDate = b.GraduationDate,
                                     University = b.University,
                                     WorkShopName = b.WorkShopName,
                                     UserName = b.UserName,
                                 }).ToListAsync();
            return vetList;
        }


        //public async Task<List<VetListViewModel>> Get()
        //{
        //    var vetList = await (from b in _context.VetUsers
        //                         select new VetListViewModel()
        //                         {
        //                             Id = (int)b.Id,
        //                             Name = b.Name,
        //                             Surname = b.SurName,
        //                             Email = b.Email,
        //                             Expertise = b.Expertise,
        //                             Gender = b.Gender,
        //                             GraduationDate = b.GraduationDate,
        //                             University = b.University,
        //                             WorkShopName = b.WorkShopName,
        //                             UserName = b.UserName,
        //                         }).ToListAsync();
        //    return vetList;
        //}





    }
}
