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
    public class MessageService
    {
        private readonly BitirmeProjesiEntities _context;
        public MessageService(BitirmeProjesiEntities context)
        {
            _context = context;
        }
        public async Task<List<MessageListViewModel>> FromUserToVetMessagesList(int questionId, UserModel user)
        {

            return await (from m in _context.FromUserToVetMessages
                          where m.QuestionsId == questionId
                          select new MessageListViewModel
                          {
                              Id = (int)m.Id,
                              ContentMessage = m.ContentMessage,
                              CreateDate = m.CreateDate,
                              FromUserId = m.FromUserId,
                              QuestionsId = m.QuestionsId,
                          }).ToListAsync().ConfigureAwait(false);
        }
        public async Task<List<FromVetToUserMessages>> FromVetToUserMessagesList(int questionId, UserModel user)
        {

            return await (from m in _context.FromVetToUserMessages
                          where m.QuestionsId == questionId
                          select new FromVetToUserMessages
                          {
                              Id = (int)m.Id,
                              ContentMessage = m.ContentMessage,
                              CreateDate = m.CreateDate,
                              QuestionsId = m.QuestionsId,
                              ToUserId = m.ToUserId,
                              Status = m.Status,
                          }).ToListAsync().ConfigureAwait(false);
        }
    }
}
