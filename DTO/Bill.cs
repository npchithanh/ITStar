using System.Collections.Generic;

namespace DTO
{
    public class Bill : Subject
    {
        public long SupplierId { get; set; }
        public List<BillDetail> BillDetails { get; set; }
    }
}
