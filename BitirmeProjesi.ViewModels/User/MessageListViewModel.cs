using BitirmeProjesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.ViewModels.User
{
    public class MessageListViewModel
    {
        public MessageListViewModel()
        {
            FromUserToVet = new List<FromUserToVetMessages>();
            FromVetToUser = new List<FromVetToUserMessages>();
        }
        public long Id { get; set; }
        public string ContentMessage { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<long> FromUserId { get; set; }
        public Nullable<long> ToUserId { get; set; }
        public Nullable<long> QuestionsId { get; set; }
        public IEnumerable<FromUserToVetMessages> FromUserToVet { get; }
        public IEnumerable<FromVetToUserMessages> FromVetToUser { get; }

        public class FromUserToVetMessages
        {
            public long Id { get; set; }
            public string ContentMessage { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<long> FromUserId { get; set; }
            public Nullable<long> ToVetId { get; set; }
            public Nullable<long> QuestionsId { get; set; }
            public Nullable<int> Status { get; set; }
        }
        public class FromVetToUserMessages
        {
            public long Id { get; set; }
            public string ContentMessage { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<long> FromVetId { get; set; }
            public Nullable<long> ToUserId { get; set; }
            public Nullable<long> QuestionsId { get; set; }
            public Nullable<int> Status { get; set; }
        }

    }
}
