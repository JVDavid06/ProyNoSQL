namespace ProyNoSQL.Entities
{
    public class ProyObj
    {
    }

    public class Usuario
    {
       
        public string id { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }

    }

    public class Inventario
    {

        public string id { get; set; }
        public string Marca { get; set; }
        public string Colores { get; set; }
        public string Tallas { get; set; }
        public string Categoria { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string IdProveedor { get; set; }


    }

    public class Proveedor
    {
        public string id { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


    }
    public class Ordenes
    {
        public string id { get; set; }
        public string FechaPedidp { get; set; }
        public string FechaEntrega { get; set; }
        public string IdPedido { get; set; }
        public string DireccionEnvio { get; set; }
        public bool Estado { get; set; }


    }
    public class Pedidos
    {
        public string id { get; set; }
        public string FormaDePago { get; set; }
        public string IdUsuario { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }


    }

    public class Horarios
    {
        public string id { get; set; }
        public string HoraInicio { get; set; }
        public string HoraSalida { get; set; }

    }


    public class Sucursales
    {
        public string id { get; set; }
        public string NombreSucursal { get; set; }
        public string DireccionSucursal { get; set; }
        public string IdHorario  { get; set; }


    }

}
