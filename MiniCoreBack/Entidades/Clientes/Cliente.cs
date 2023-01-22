using Entidades.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clientes
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }

        public virtual List<Contrato> Contratos { get; set; }
    }
}
