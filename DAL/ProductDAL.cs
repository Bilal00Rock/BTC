using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ProductDAL
    {
        public void Create(Product p)
        {
            DB db = new DB();
            db.Products.Add(p);
           
            db.SaveChanges();
        }
        public List<Product> Read()
        {
            DB db = new DB();
            return db.Products.ToList();
        }
    }
}
