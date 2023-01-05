using ControlAPI.Entities;

namespace ControlApi.DTO
{
    public class BillDTORs
    {
        public int Id { get; set; }
        public int NumBill { get; set; }
        public string Client { get; set; }
        public string DocumentClient { get; set; }
        public int NumberClient { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
    }
}
