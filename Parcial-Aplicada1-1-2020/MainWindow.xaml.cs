using Parcial_Aplicada1_1_2020.BLL;
using Parcial_Aplicada1_1_2020.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parcial_Aplicada1_1_2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProductIdTex.Text = "0";
        }

        private void Limpiar()
        {
            ProductIdTex.Text = string.Empty;
            DescripcionTex.Text = string.Empty;
            ExistenciaTex.Text = string.Empty;
            ProductIdTex.Text = "0";
            CostoTex.Text = "0";
            ValorInventarioTex.Text = "0";
           
        }

        private Productos LlenaClase()
        {
            Productos productos = new Productos();

            productos.ProductoId = Convert.ToInt32(ProductIdTex.Text);
            productos.Descripcion = DescripcionTex.Text;
            productos.Existencia = Convert.ToDecimal(ExistenciaTex.Text);
            productos.Costo = Convert.ToDecimal(CostoTex.Text);
            productos.ValorInventario = Convert.ToDecimal(ValorInventarioTex.Text);

            return productos;
        }

        private void LlenaCampo(Productos productos)
        {
            ProductIdTex.Text = Convert.ToString(productos.ProductoId);
            DescripcionTex.Text = productos.Descripcion;
            ExistenciaTex.Text = Convert.ToString(productos.Existencia);
            CostoTex.Text = Convert.ToString(productos.Costo);
            ValorInventarioTex.Text = Convert.ToString(productos.ValorInventario);

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos productos;
            bool paso = false;
            if (!Validar())
                return;

            productos = LlenaClase();

            if (Convert.ToInt32(ProductIdTex.Text) == 0)
                paso = ProductosBLL.Guardar(productos);

            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No puede Modificar un Producto que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                paso = ProductosBLL.Modificar(productos);
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardar!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible guardar el Producto!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private bool ExisteEnLaBaseDeDatos()
        {
           Productos estudiante = ProductosBLL.Buscar(Convert.ToInt32(ProductIdTex.Text));
            return (estudiante != null);
        }

       
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductIdTex.Text, out id);

            Limpiar();

            if (ProductosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Productos productos = new Productos();
            int.TryParse(ProductIdTex.Text, out id);

            Limpiar();
            productos = ProductosBLL.Buscar(id);
            if (productos != null)
            {

                LlenaCampo(productos);
            }
            else
            {
                MessageBox.Show("Persona NO Encontrada...");
            }

        }
        private bool Validar()
        {
            bool paso = true;
            if (DescripcionTex.Text == "")
            {
                MessageBox.Show("El Campo descripcion No puede estar Vacio");
                DescripcionTex.Focus();
                paso = false;

            }
            if (ExistenciaTex.Text == "0")
            {
                MessageBox.Show("El Campo Existencia No puede estar vacio");
                ExistenciaTex.Focus();
                paso = false;
            }
            if (CostoTex.Text == "0")
            {
                MessageBox.Show("EL campo Costo no puede estar vacio");
                CostoTex.Focus();
                paso = false;
            }

            return paso;
        }

        private void ExistenciaTex_TextChanged(object sender, TextChangedEventArgs e)
        {

            decimal costo = 0;
            decimal existencia = 0;

            if (!string.IsNullOrWhiteSpace(CostoTex.Text) && CostoTex.Text != "-")
            {
                costo = decimal.Parse(CostoTex.Text);
            }
            if (!string.IsNullOrWhiteSpace(ExistenciaTex.Text) && ExistenciaTex.Text != "-")
            {
                existencia = decimal.Parse(ExistenciaTex.Text);
            }

            decimal perdido = costo * existencia;

            ValorInventarioTex.Text = perdido.ToString();

        }

        private void CostoTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            decimal costo = 0;
            decimal existencia = 0;

            if (!string.IsNullOrWhiteSpace(CostoTex.Text) && CostoTex.Text != "-")
            {
                costo = decimal.Parse(CostoTex.Text);
            }
            if (!string.IsNullOrWhiteSpace(ExistenciaTex.Text) && ExistenciaTex.Text != "-")
            {
                existencia = decimal.Parse(ExistenciaTex.Text);
            }

            decimal perdido = costo * existencia;
          
            ValorInventarioTex.Text = perdido.ToString();
            
        }
    }
}
