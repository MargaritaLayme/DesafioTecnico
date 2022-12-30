using ApiWebVentaComercial.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWebVentaComercial.Context
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<VentaAsesor> VentaAsesor { get; set; }
    }
}
