namespace Common
{
    public class OrderInfo
    { 
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int Status { get; set; }

        public Guid? UserId { get; set; }
    }
}
