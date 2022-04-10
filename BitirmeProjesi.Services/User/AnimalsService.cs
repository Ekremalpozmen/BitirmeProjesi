using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.User;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.User
{
    public class AnimalsService
    {
        private readonly BitirmeProjesiEntities _context;
        public AnimalsService(BitirmeProjesiEntities context)
        {
            _context = context;
        }
        public List<AnimalsViewModel> AnimalsList(AnimalsViewModel model, UserModel user)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BitirmeProjesiConnectionString"].ConnectionString))
            {
                string _sql = @"  
                                SELECT [Id]
                                      ,[Name]
                                      ,[Type]
                                      ,[Birthdate]
                                      ,[Gender]
                                      ,[UserId]
                                  FROM [BitirmeProjesi].[dbo].[Animals] where UserId=@userId";
                var animalsList = (db.Query<AnimalsViewModel>(_sql, new { userId = user.Id })).ToList();
                return animalsList;
            }
        }
    }
}
