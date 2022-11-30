using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp10000.Models.Entities;

namespace WpfApp10000.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
