using ApiWebVentaComercial.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebVentaComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaAsesorController : ControllerBase
    {
        private static List<VentaAsesor> listaventas = new List<VentaAsesor>
        {
            new VentaAsesor
            {
                Id = 1,
                AsesorNombre="Matilde Quispe",
                ClienteNombre="Hector Gallan",
                IdProducto=1,
                Monto = 25000
            },
             new VentaAsesor
            {
                Id = 2,
                AsesorNombre="Juana Condori",
                ClienteNombre="Juan Mamani",
                IdProducto=2,
                Monto = 35000
            }
        };
        [HttpGet]
        //[Route("listar")]
        public async Task<ActionResult<List<VentaAsesor>>> listaVentaAsesor()
        {
            return Ok(listaventas);
        }
         [HttpGet("{id}")]
        //[HttpGet]
        public async Task<ActionResult<VentaAsesor>> ObtieneVentaAsesorPorID(int id)
        {
            var venta = listaventas.Find(x => x.Id == id);
            if (venta == null)
                return BadRequest("Venta no encontrada");
            return Ok(venta);
        }
        [HttpPost]        
        public async Task<ActionResult<List<VentaAsesor>>> AgregaVentaAsesor(VentaAsesor venta)
        {
            listaventas.Add(venta);
            return Ok(listaventas);
        }
        [HttpPut]
        public async Task<ActionResult<List<VentaAsesor>>> ActualizaVentaAsesor(VentaAsesor request)
        {
            var venta = listaventas.Find(x => x.Id == request.Id);
            if (venta == null)
                return BadRequest("Venta no encontrada");
            venta.AsesorNombre = request.AsesorNombre;
            venta.ClienteNombre = request.ClienteNombre;
            venta.IdProducto = request.IdProducto;
            venta.Monto = request.Monto;
            //listaventas.(venta);
            return Ok(listaventas); 
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentaAsesor>> EliminaVentaAsesor(int id)
        {
            var venta = listaventas.Find(x => x.Id == id);
            if (venta == null)
                return BadRequest("Venta no encontrada");
            listaventas.Remove(venta);
            return Ok(venta);
        }
    }
}
