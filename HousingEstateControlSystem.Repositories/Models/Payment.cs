
namespace HousingEstateControlSystem.Repositories.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string UserId { get; set; } // Ödemenin hangi kullanıcı tarafından yapıldığını belirtmek için kullanıcı ID'si
        public User User { get; set; } 
        public int DuesId { get; set; } // Ödemenin hangi aidat ID'sine ait olduğunu belirtmek için aidat ID'si
        public decimal Amount { get; set; } // Ödeme tutarı
        public DateTime PaymentDate { get; set; } // Ödemenin yapıldığı tarih
        public PaymentType PaymentType { get; set; } // Ödeme türü (Aidat/Fatura)
    }

    public enum PaymentType
    {
        Dues,
        Bill
    }
}
