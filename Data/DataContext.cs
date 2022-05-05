using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Data
{
    public class DataContext: DbContext{
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public virtual DbSet<Product> Products {get; set;}
        public virtual DbSet<Supplier> Suppliers {get; set;}
        public virtual DbSet<SupplierService> SupplierServices {get; set;}

    }
}