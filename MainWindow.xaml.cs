using RegistroPersona.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RegistroPersona.BLL;

namespace RegistroPersona
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


        private void Limpiar()
        {
            IdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
       
        }

        private Persona LlenaClase()
        {
            Persona personas = new Persona();
            personas.PersonaId = Convert.ToInt32(IdTextBox.Text);

            //idTextBox.Text.ToInt();
            personas.Nombres = NombresTextBox.Text;
            return personas;
        }

        private void LlenaCampo(Persona personas)
        {
            IdTextBox.Text = Convert.ToString(personas.PersonaId);
            NombresTextBox.Text = personas.Nombres;
   
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            Persona personas;
            bool paso = false;

            if (!Validar())
                return;

            personas = LlenaClase();

            //Determinar si es guardar o modificar
            if (IdTextBox.Text.ToInt() == 0)

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = PersonaBLL.Guardar(personas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonaBLL.Modificar(personas);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Persona personas = PersonaBLL.Buscar((int)IdTextBox.Text.ToInt());
            return (personas != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (NombresTextBox.Text == string.Empty)
            {
                MessageBox.Show(NombresTextBox.Text, "El campo Nombre no puede estar vacio ");
                NombresTextBox.Focus();
                paso = false;
            }

            Persona personas = PersonaBLL.Buscar((int)IdTextBox.Text.ToInt());
            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
