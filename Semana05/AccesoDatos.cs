using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Semana05
{
    public class AccesoDatos
    {
        private const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Database=Neptuno;Integrated Security=True;TrustServerCertificate=True";

        public List<Producto> ObtenerProductos()
        {
            var lista = new List<Producto>();
            using var conexion = new SqlConnection(CadenaConexion);
            using var comando = new SqlCommand("USP_ListarProductos", conexion) { CommandType = CommandType.StoredProcedure };
            conexion.Open();
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Producto
                {
                    IdProducto = (int)lector["idproducto"],
                    NombreProducto = lector["nombreProducto"].ToString() ?? string.Empty,
                    CantidadPorUnidad = lector["cantidadPorUnidad"].ToString() ?? string.Empty,
                    PrecioUnidad = (decimal)lector["precioUnidad"],
                    UnidadesEnExistencia = (short)lector["unidadesEnExistencia"]
                });
            }
            return lista;
        }

        public List<Categoria> ObtenerCategorias()
        {
            var lista = new List<Categoria>();
            using var conexion = new SqlConnection(CadenaConexion);
            using var comando = new SqlCommand("USP_ListarCategorias", conexion) { CommandType = CommandType.StoredProcedure };
            conexion.Open();
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Categoria
                {
                    IdCategoria = (int)lector["idcategoria"],
                    NombreCategoria = lector["nombrecategoria"].ToString() ?? string.Empty,
                    Descripcion = lector["descripcion"].ToString() ?? string.Empty
                });
            }
            return lista;
        }

        public List<Proveedor> BuscarProveedores(string contacto, string ciudad)
        {
            var lista = new List<Proveedor>();
            using var conexion = new SqlConnection(CadenaConexion);
            using var comando = new SqlCommand("USP_BuscarProveedores", conexion) { CommandType = CommandType.StoredProcedure };
            comando.Parameters.AddWithValue("@nombrecontacto", contacto);
            comando.Parameters.AddWithValue("@ciudad", ciudad);
            conexion.Open();
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Proveedor
                {
                    IdProveedor = (int)lector["idProveedor"],
                    NombreCompania = lector["nombreCompañia"].ToString() ?? string.Empty,
                    NombreContacto = lector["nombrecontacto"].ToString() ?? string.Empty,
                    Ciudad = lector["ciudad"].ToString() ?? string.Empty,
                    Pais = lector["pais"].ToString() ?? string.Empty,
                    Telefono = lector["telefono"].ToString() ?? string.Empty
                });
            }
            return lista;
        }
    }
}
