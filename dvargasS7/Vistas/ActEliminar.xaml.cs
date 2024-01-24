using dvargasS7.Modelo;
using System.Net;

namespace dvargasS7.Vistas;

public partial class ActEliminar : ContentPage
{
	public ActEliminar(Estudiantes datos)
	{
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.1.32:8080/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad, "PUT", parametros);
            Navigation.PushAsync(new Inicio());

        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnACtualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.1.32:8080/moviles/post.php?codigo=" + codigo, "DELETE", parametros);
            Navigation.PushAsync(new Inicio());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}