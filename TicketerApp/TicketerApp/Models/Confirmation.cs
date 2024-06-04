namespace TicketerApp.Models
{
    public class Confirmation : BasicModel
    {
        public int PaymentId { get; set; }
        public int CorrectConfirmationAnswer { get; set; }
        public string EventTitle { get; set; }
        public float PriceToPay { get; set; }
        public bool MfaRequired { get; set; }
        public string MfaCode { get; set; }
    }
}
