﻿using BitirmeProjesi.Data;
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


        public async Task<ServiceCallResult> AddQuestion(QuestionViewModel model, UserModel user)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var question = new Questions()
            {
                Title = model.Title,
                Description = model.Description,
                RatingScore = 0,
                UserId = user.Id,
                VetId = model.VetId,
                CreateDate = DateTime.Now,
            };
            _context.Questions.Add(question);


            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
            };

            var messages = new Messages()
            {
                ContentMessage = model.Description,
                CreateDate = DateTime.Now,
                FromUserId = user.Id,
                ToUserId = model.VetId,
                QuestionsId = question.Id,
                Status = 1
            };
            _context.Messages.Add(messages);


            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
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
