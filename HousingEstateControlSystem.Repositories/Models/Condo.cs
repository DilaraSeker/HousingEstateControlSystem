using System;

namespace HousingEstateControlSystem.Repositories.Models
{
    public class Condo
    {
        public int CondoId { get; set; }
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool Owner { get; set; } // false if it is rented
    }
}
