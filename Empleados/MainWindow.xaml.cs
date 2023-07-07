using Empleados.Entities;
using Empleados.Services;
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

namespace Empleados23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            EmpleadoServices services = new EmpleadoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text,
                FechaRegistro = DateTime.Now,
            };
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("FALTAN CAMPOS POR LLENAR");
            }
            else
            {
                services.Add(empleado);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("REGISTRO EXITOSO");
            }
        }
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            Empleado empleado = services.Red(Id);
            if (empleado != null)
            {
                txtId.Text = empleado.PKEmpleado.ToString();
                txtNombre.Text = empleado.Nombre.ToString();
                txtApellido.Text = empleado.Apellido.ToString();
                txtCorreo.Text = empleado.Correo.ToString();
                txtFecha.Text = empleado.FechaRegistro.ToString();
            }
            else
            {
                MessageBox.Show("REGISTRO NO ENCONTRADO");
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
                txtId.Clear();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("CAMPO ID POR LLENAR");
            }
            else
            {
                services.Delete(Id);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
                txtId.Clear();
                MessageBox.Show("REGISTRO ELIMINADO");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);

            

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("FALTAN CAMPOS POR LLENAR");
            }
            else
            {
                Empleado empleado = new Empleado();
                empleado.PKEmpleado = Id;
                empleado.Nombre = txtNombre.Text;
                empleado.Apellido = txtApellido.Text;
                empleado.Correo = txtCorreo.Text;
                empleado.FechaRegistro = DateTime.Now;
                services.Update(empleado);

                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
                MessageBox.Show("REGISTRO MODIFICADO");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtFecha.Clear();
            txtId.Clear();
        }
    }
}
