using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateControlSystem.DTOs.Condo
{
    public class CondoDTO
    {
        public int CondoId { get; set; }
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }
        public bool IsTenant { get; set; }
    }
}
