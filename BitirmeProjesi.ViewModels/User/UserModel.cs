using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.ViewModels.User
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName
        {
            get { return Name + ", " + SurName; }
        }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
