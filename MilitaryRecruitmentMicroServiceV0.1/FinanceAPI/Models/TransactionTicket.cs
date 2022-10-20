
using System;
using System.ComponentModel.DataAnnotations;
namespace FinanceAPI.Models
{
    public class TransactionTicket
    {
        [Key]
        public int TicketId { get; set; }
        public string TicketType { get; set; }
        public int UserID { get; set; }
        public float Amount { get; set; }
        public string CurrencyType { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ExternalNotes { get; set; }
        public bool financialclear { get; set; }
    }
}
