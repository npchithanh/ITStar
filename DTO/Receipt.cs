using System.Collections.Generic;

namespace DTO
{
    public class Receipt : Subject
    {
        public long CustomerId { get; set; }
        public List<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
