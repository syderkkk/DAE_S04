USE [Neptuno]
GO

CREATE OR ALTER PROC USP_ListarProductos
AS
BEGIN
    SELECT idproducto, nombreProducto, idProveedor, idCategoria, cantidadPorUnidad,
           precioUnidad, unidadesEnExistencia, unidadesEnPedido, nivelNuevoPedido, suspendido
    FROM productos
END
GO

CREATE OR ALTER PROC USP_ListarCategorias
AS
BEGIN
    SELECT idcategoria, nombrecategoria, descripcion, Activo, CodCategoria
    FROM categorias
END
GO

CREATE OR ALTER PROC USP_ListarProveedores
AS
BEGIN
    SELECT idProveedor, nombreCompañia, nombrecontacto, cargocontacto, direccion,
           ciudad, region, codPostal, pais, telefono, fax
    FROM proveedores
END
GO

CREATE OR ALTER PROC USP_BuscarProveedores
    @nombrecontacto VARCHAR(50) = '',
    @ciudad VARCHAR(50) = ''
AS
BEGIN
    SELECT idProveedor, nombreCompañia, nombrecontacto, cargocontacto, direccion,
           ciudad, region, codPostal, pais, telefono, fax
    FROM proveedores
    WHERE nombrecontacto LIKE '%' + @nombrecontacto + '%'
      AND ciudad LIKE '%' + @ciudad + '%'
END
GO

CREATE OR ALTER PROC USP_DetallesPedidosPorFecha
    @fechaInicio DATE,
    @fechaFin DATE
AS
BEGIN
    SELECT d.idpedido, d.idproducto, d.preciounidad, d.cantidad, d.descuento,
           p.FechaPedido, p.IdCliente, p.IdEmpleado
    FROM detallesdepedidos d
    INNER JOIN Pedidos p ON d.idpedido = p.IdPedido
    WHERE p.FechaPedido BETWEEN @fechaInicio AND @fechaFin
END
GO
