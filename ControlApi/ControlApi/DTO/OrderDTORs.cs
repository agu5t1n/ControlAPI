namespace ControlApi.DTO
{
    public class OrderDTORs
    {
        public int Id { get; set; }
        public int NumBill { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
        public double Subtotal { get; set; }
        public int IdBill { get; set; }
        public int IdProduct { get; set; }
    }
}
