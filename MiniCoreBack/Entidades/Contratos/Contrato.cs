using Entidades.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contratos
{
    [Table("Contratos")]
    public class Contrato
    {
        [Key]
        public int idContrato { get; set; }
        [Required]
        public int idCliente_FK { get; set; }
        [AllowNull]
        public string NombreContrato { get; set; }
        [AllowNull]
        public double Montos { get; set; }
        [AllowNull]
        public DateTime Fecha { get; set; }

        [ForeignKey("idCliente_FK")]

        public virtual Cliente cliente { get; set; }
    }
}
