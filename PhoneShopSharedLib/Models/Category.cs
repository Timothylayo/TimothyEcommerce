using System.ComponentModel.DataAnnotations;

namespace PhoneShopSharedLib.Models
{
    public class Category
    {
        public int Id {  get; set; }
        [Required]
        public string? Name { get; set; }

        //Relationship onr - many
        public List<Product>? Products { get; set;}
    }
}
