using Entidades.Contratos;

namespace MiniCore.Models.Clientes
{
    public class ClientesViewModel
    {
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }

        public virtual List<Contrato> Contratos { get; set; }
    }
}
