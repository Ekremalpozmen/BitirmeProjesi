using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.Common;
using BitirmeProjesi.ViewModels.User;
using BitirmeProjesi.ViewModels.Vet;
using Dapper;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.Vet
{
    public class QuestionService
    {
        private readonly BitirmeProjesiEntities _context;
        public QuestionService(BitirmeProjesiEntities context)
        {
            _context = context;
        }
        public List<QuestionListViewModel> QuestionList(QuestionListViewModel model, UserModel user)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BitirmeProjesiConnectionString"].ConnectionString))
            {
                string _sql = @" SELECT TOP (1000) q.Id
                                 ,[Title]
                                 ,[UserId]
                                 ,[VetId]
                              	 ,vu.Name as UserName
                              	 ,vu.SurName as UserSurName
                                 FROM [BitirmeProjesi].[dbo].[Questions] q INNER JOIN [dbo].VetUsers vu ON vu.Id=q.VetId where q.VetId=@userId";
                var questionList = (db.Query<QuestionListViewModel>(_sql, new { userId = user.Id })).ToList();
                return questionList;
            }
        }
    }
}
