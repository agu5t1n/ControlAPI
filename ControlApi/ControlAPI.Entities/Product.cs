using System.ComponentModel.DataAnnotations;

namespace ControlAPI.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int IdCategory { get; set; }
        //public int IdSale { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Order> Order { get; set; }

    }
}