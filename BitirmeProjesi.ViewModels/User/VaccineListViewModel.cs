using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.ViewModels.User
{
    public class VaccineListViewModel
    {
        public int? Id { get; set; }
        public int? AnimalId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime RecurrenceDate { get; set; }
    }
}
