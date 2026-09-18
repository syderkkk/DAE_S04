using System.Windows;

namespace Semana05
{
    public partial class MainWindow : Window
    {
        private readonly AccesoDatos accesoDatos = new();

        public MainWindow()
        {
            InitializeComponent();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            dgProductos.ItemsSource = accesoDatos.ObtenerProductos();
            dgCategorias.ItemsSource = accesoDatos.ObtenerCategorias();
            dgProveedores.ItemsSource = accesoDatos.BuscarProveedores("", "");
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dgProveedores.ItemsSource = accesoDatos.BuscarProveedores(txtContacto.Text, txtCiudad.Text);
        }
    }
}
