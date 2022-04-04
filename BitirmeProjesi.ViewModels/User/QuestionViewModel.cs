using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.ViewModels.User
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int VetId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
