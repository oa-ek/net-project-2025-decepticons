namespace ShubkivTour.Models.DTO
{
    public class BusinessPaymentDto
    {
        public string ApiKey { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Ptk { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }

}
