namespace WebApp.Models
{
    public class Invoice
    {
        public string InvoiceId { get; set; }
        public string CartCode { get; set; }
        public int AddressId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public byte StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
