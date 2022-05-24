using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.ViewModels.Vet
{
    public class VetModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName
        {
            get { return Name + ", " + SurName; }
        }
        public string Email { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string University { get; set; }
        public string Expertise { get; set; }
        public Nullable<System.DateTime> GraduationDate { get; set; }
        public string WorkShopName { get; set; }
        public string PhoneNumber { get; set; }
        public class EditPassword
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string NewPasswordAgain { get; set; }
        }
    }
}
