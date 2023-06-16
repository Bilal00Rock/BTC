using BE;
using DAL;

namespace BLL
{
    public class ProductBLL
    {
        public void Create(Product product)
        {
            ProductDAL p = new ProductDAL();
            p.Create(product);
        }
        public List<Product> Read()
        {
            ProductDAL p = new ProductDAL();
            return p.Read();
        }
    }
}