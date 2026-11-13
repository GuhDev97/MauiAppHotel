namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        // Retorna à página anterior da pilha de navegação
        await Navigation.PopAsync();
    }
}
