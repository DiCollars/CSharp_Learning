using Common;

namespace OrderService
{
    public class OrderEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public OrderStatus Status { get; set; }

        public Guid? UserId { get; set; }

        public decimal Costs { get; set; }
    }
}
