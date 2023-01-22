using Entidades.Clientes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MiniCore.Models.Clientes;

namespace MiniCore.Models.Contratos
{
    public class ContratosViewModel
    {
        public int idContrato { get; set; }
        public int idCliente_FK { get; set; }
        public string NombreContrato { get; set; }
        public double Montos { get; set; }
        public DateTime Fecha { get; set; }

        public ClientesViewModel cliente { get; set; }
    }
}
