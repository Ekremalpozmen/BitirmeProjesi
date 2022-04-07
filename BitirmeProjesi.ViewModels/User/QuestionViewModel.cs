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
        public int UserId { get; set; }
        public string VetName { get; set; }
        public string VetSurName { get; set; }
        public string VetFullName
        {
            get { return VetName + " " + VetSurName; }
        }
        public int VetId { get; set; }
        public decimal RatingScore { get; set; }
    }
}
