
namespace HousingEstateControlSystem.Repositories.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Ödemenin hangi kullanıcı tarafından yapıldığını belirtmek için kullanıcı ID'si
        public int DuesId { get; set; } // Ödemenin hangi aidat ID'sine ait olduğunu belirtmek için aidat ID'si
        public decimal Amount { get; set; } // Ödeme tutarı
        public DateTime PaymentDate { get; set; } // Ödemenin yapıldığı tarih
        public PaymentType Type { get; set; } // Ödeme türü (Aidat/Fatura)
    }

    public enum PaymentType
    {
        Dues,
        Bill
    }
}
