namespace Semana05
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string CantidadPorUnidad { get; set; } = string.Empty;
        public decimal PrecioUnidad { get; set; }
        public short UnidadesEnExistencia { get; set; }
    }

    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }

    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreCompania { get; set; } = string.Empty;
        public string NombreContacto { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}
