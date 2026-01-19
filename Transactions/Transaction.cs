using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Merchant { get; set; }
        public string Category { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
