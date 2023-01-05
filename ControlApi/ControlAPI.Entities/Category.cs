using System.ComponentModel.DataAnnotations;

namespace ControlAPI.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual List<Product> Product { get; set; }

    }
}