using Datos;
using Entidades.Clientes;
using Entidades.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCore.Models.Clientes;
using MiniCore.Models.Contratos;
using System.Web.Http.Cors;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniCore.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly DbContextCore _context;

        public ReporteController(DbContextCore context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet("[action]")]
        public async Task<List<List<string>>> Resultado(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<List<string>> resultados = new List<List<string>>();

            var listClientes = await _context.Clientes.ToListAsync();

            var listContratos = await _context.Contratos.Include(client => client.cliente).ToListAsync();
            listContratos.Select(c => new ContratosViewModel
            {
                idContrato = c.idContrato,
                idCliente_FK = c.idCliente_FK,
                NombreContrato = c.NombreContrato,
                Montos = c.Montos,
                Fecha = c.Fecha,
                cliente = new ClientesViewModel
                {
                    NombreCliente = c.cliente.NombreCliente
                },
            });

            double total = 0;

            List<DateTime> listFechas = new List<DateTime>();
            listFechas.Add(fechaDesde);
            DateTime fechaTemp = fechaDesde;
            while(fechaTemp.CompareTo(fechaHasta) < 0)
            {
                fechaTemp = fechaTemp.AddDays(1);
                listFechas.Add(fechaTemp);  
            }


            foreach (Cliente temp in listClientes)
            {
                List<string> clients= new List<string>();
                clients.Add(temp.NombreCliente);

                double sumaMontos = 0;

                foreach (Contrato cont in listContratos)
                {
                    foreach (DateTime f in listFechas)
                    {
                        if (cont.cliente.idCliente == temp.idCliente && f.CompareTo(cont.Fecha) == 0)
                        {
                            sumaMontos += cont.Montos;
                            total += sumaMontos;
                        }
                    }
                    
                }

                clients.Add(sumaMontos.ToString("0.##"));

                resultados.Add(clients);
            }

            List<string> totales = new List<string>();
            totales.Add("Total");
            totales.Add(total.ToString("0.##"));

            resultados.Add(totales);

            return resultados;
        }

    }
}
