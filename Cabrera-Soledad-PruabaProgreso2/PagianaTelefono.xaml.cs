using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace Cabrera_Soledad_PruabaProgreso2;

public partial class PagianaTelefono : ContentPage
{
    public string UltimaRecarga { get; set; }

    public PagianaTelefono()
	{
		InitializeComponent();
        BindingContext = this;
        CargarUltimaRecarga();

    }

    private void scabrera_buttonRecargar_Clicked(object sender, EventArgs e)
    {
        var nombre = scabrera_entryNombre.Text;
        var telefono = scabrera_entryTelefono.Text;

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
        {
            DisplayAlert("Error", "Por favor ingrese todos los datos.", "Okey");
            return;
        }

        var datos = $"Nombre: {nombre}, Teléfono: {telefono}, Fecha: {DateTime.Now}";
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SoledadCabrera.txt");

        File.WriteAllText(filePath, datos);
        DisplayAlert("Éxito", "Recarga realizada correctamente.", "Okey");
        CargarUltimaRecarga();
    }
    private void CargarUltimaRecarga()
    {
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SoledadCabrera.txt");

        if (File.Exists(filePath))
        {
            UltimaRecarga = File.ReadAllText(filePath);
        }
        else
        {
            UltimaRecarga = "No hay recargas previas.";
        }

        OnPropertyChanged(nameof(UltimaRecarga));
    }


}