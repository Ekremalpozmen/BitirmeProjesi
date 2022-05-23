using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.ViewModels.Vet
{
    public class QuestionListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserFullName
        {
            get { return UserName + " " + UserSurName; }
        }
        public int VetId { get; set; }
    }
}
