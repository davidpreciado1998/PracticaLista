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

namespace PracticaLista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Alumno> alumnos = new List<Alumno>();

        public MainWindow()
        {
            InitializeComponent();

            Materia historia = new Materia("HST123", "Historia");
            Materia matematicas = new Materia("MAT456", "Matematicas");
            Materia civismo = new Materia("CIV741", "Civismo");
            Materia español = new Materia("ESP963", "Español");
            Materia artistica = new Materia("ART852", "Artistica");

            alumnos.Add(new Alumno("Jose Pérez", "153697", "Lic. en Derecho"));
            alumnos.Add(new Alumno("Juan López", "581269", "Lic. en Psicologia"));
            alumnos.Add(new Alumno("Cristian García", "153697", "Lic. en Finanzas"));
            alumnos.Add(new Alumno("María Valenzuela", "142536", "Ing. Civil"));

            //Primer alumno
            alumnos[0].Materias.Add(español);
            alumnos[0].Materias.Add(artistica);
            //Segundo
            alumnos[1].Materias.Add(civismo);
            alumnos[1].Materias.Add(matematicas);
            //Tercero
            alumnos[2].Materias.Add(historia);
            alumnos[2].Materias.Add(español);
            //Cuarto
            alumnos[3].Materias.Add(civismo);
            alumnos[3].Materias.Add(artistica);

            foreach (Alumno alumno in alumnos)
            {
                lstAlumnos.Items.Add(new ListBoxItem() {Content = alumno.Nombre} );
            }
        }

        private void lstAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblNombre.Text = alumnos[lstAlumnos.SelectedIndex].Nombre;
            lblMatricula.Text = alumnos[lstAlumnos.SelectedIndex].Matricula;
            lblCarrera.Text = alumnos[lstAlumnos.SelectedIndex].Carrera;

            lstMaterias.Items.Clear();

            foreach (Materia materia in alumnos[lstAlumnos.SelectedIndex].Materias)
            {
                lstMaterias.Items.Add(new ListBoxItem() { Content = materia.Nombre });
            }
        }

        private void lstMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstMaterias.SelectedIndex != -1)
            {
                lblClave.Text = alumnos[lstAlumnos.SelectedIndex].Materias[lstMaterias.SelectedIndex].Clave;
                lblNombreMateria.Text = alumnos[lstAlumnos.SelectedIndex].Materias[lstMaterias.SelectedIndex].Nombre;
            }
        }
    }
}
