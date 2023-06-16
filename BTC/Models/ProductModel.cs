using BE;

namespace BTC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        // New property for picture
        public IFormFile PictureFileName { get; set; }
      
    }
}
