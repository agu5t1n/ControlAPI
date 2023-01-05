using System.ComponentModel.DataAnnotations;

namespace ControlAPI.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public int NumBill { get; set; }
        public string Client { get; set; }
        public string DocumentClient { get; set; }
        public int NumberClient { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Order> Order{ get; set; }

    }
}