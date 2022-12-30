namespace ApiWebVentaComercial.Models
{
    public class VentaAsesor
    {
        public int Id { get; set; } 
        public string AsesorNombre { get; set; }
        public string ClienteNombre { get; set; }
        public int IdProducto { get; set; }//Ejemplo productos: 1: Credito Personal, 2: Credito Hipotecario, 3: Otros
        public float Monto { get; set; }

    }
}
