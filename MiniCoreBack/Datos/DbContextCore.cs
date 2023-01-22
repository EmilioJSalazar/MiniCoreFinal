using Datos.Mapping;
using Entidades.Clientes;
using Entidades.Contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Datos
{
    public class DbContextCore: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        

        //CONSTRUCTOR 
        public DbContextCore(DbContextOptions<DbContextCore> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//nos permite mapear las entidades con la base de datos

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientesMap());//Aplicar la configuracion de ClientesMap

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=LAPTOP-1745L0OO; Database=MiniCore; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=TrueEncrypt=false;TrustServerCertificate=true");
                optionsBuilder.UseSqlServer("Server=sql8001.site4now.net; Database=db_a9391a_minicore; User ID=db_a9391a_minicore_admin; Password=yh@P4rputpL9@G4; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=TrueEncrypt=false;TrustServerCertificate=true");

            }
        }
    }
}
