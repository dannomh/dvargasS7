using dvargasS7.Modelo;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dvargasS7.Vistas;

public partial class Inicio : ContentPage
{
    private const string Url = "http://192.168.1.32:8080/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiantes> estud;

    public Inicio()
    {
        InitializeComponent();
        Obtener();
    }

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Estudiantes> mostrarEst = JsonConvert.DeserializeObject<List<Estudiantes>>(content);
        estud = new ObservableCollection<Estudiantes>(mostrarEst);
        listaEstudiantes.ItemsSource = estud;
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiantes)e.SelectedItem;
        Navigation.PushAsync(new ActEliminar(objEstudiante));
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarEstudiante());
    }
}