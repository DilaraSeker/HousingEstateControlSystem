using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateControlSystem.Repositories.Models
{
    public class Dues
    {
        public int DuesId { get; set; }
        public int CondoId { get; set; } // Foreign key for Condo
        public decimal Amount { get; set; }
        public DateTime MonthYear { get; set; }
        public bool IsPaid { get; set; }
    }
}
