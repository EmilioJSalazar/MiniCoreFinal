using Entidades.Clientes;
using Entidades.Contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DbContextCoreFactory : IDesignTimeDbContextFactory<DbContextCore>
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbContextCore CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextCore>();
            //optionsBuilder.UseSqlServer("Server=LAPTOP-1745L0OO\\MSSQLLocalDB;Database=MiniCore;Trusted_Connection=True;MultipleActiveResultSets=trueEncrypt=false;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=sql8001.site4now.net;Database=db_a9391a_minicore;User ID=db_a9391a_minicore_admin;Password=yh@P4rputpL9@G4;Trusted_Connection=True;MultipleActiveResultSets=trueEncrypt=false;TrustServerCertificate=true");
            return new DbContextCore(optionsBuilder.Options);
        }
    }
}
