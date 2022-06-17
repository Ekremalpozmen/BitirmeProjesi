using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.User;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public List<VetListViewModel> GetVetListViewModel()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BitirmeProjesiConnectionString"].ConnectionString))
            {
                string _sql = @"SELECT convert(decimal(8,2),round(Avg(q.RatingScore+0.0),2)) as RatingScore,v.Name,v.SurName as Surname ,v.Id FROM [BitirmeProjesi].[dbo].[Questions] q 
                                INNER JOIN [BitirmeProjesi].[dbo].[VetUsers] v ON q.VetId=v.Id   GROUP BY	V.Id,v.Name,v.SurName";
                var vetList = (db.Query<VetListViewModel>(_sql)).ToList();
                return vetList;
            }
        }

        public VetListViewModel GetVetProfile(int vetId)
        {
            var vetProfile = from b in _context.VetUsers
                             where b.Id == vetId
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
                                 PhoneNumber = b.PhoneNumber,
                             };
            return vetProfile.FirstOrDefault();
        }
    }
}
