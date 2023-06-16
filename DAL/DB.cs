using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB : IdentityDbContext<UserApp>
    {

       
        public DB(DbContextOptions<DB> options) : base() { }

        public DB()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=BTCnew;TrustServerCertificate=True; Integrated Security=true; User ID = t2; Password =1234");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }

    }
}
