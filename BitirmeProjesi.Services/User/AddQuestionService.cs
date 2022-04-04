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
    public class AddQuestionService
    {
        private readonly BitirmeProjesiEntities _context;
        public AddQuestionService(BitirmeProjesiEntities context)
        {
            _context = context;
        }

        public async Task<List<VetListViewModel>> GetVetListViewAsync()
        {

            return await (from v in _context.VetUsers
                          select new VetListViewModel
                          {
                              Id = (int)v.Id,
                              Name = v.Name,
                              Surname = v.SurName

                          }).ToListAsync().ConfigureAwait(false);
        }


        public ServiceCallResult AddQuestion(QuestionViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var question = new Questions()
            {
                Title = model.Title,
                Description = model.Description,
                RatingScore = 0,
                UserId = 1,
                VetId = model.VetId,
                CreateDate = DateTime.Now,
            };

            _context.Questions.Add(question);

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.SuccessMessages.Add("Soru başarıyla eklendi.");
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
