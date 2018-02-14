using System.Collections.Generic;

namespace DTO
{
    public class Order : Subject
    {
        public long AccountId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
