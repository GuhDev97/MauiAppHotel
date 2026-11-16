using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class App : Application
{
    // Lista global de quartos acessível em todo o aplicativo
    public List<Quarto> lista_quartos { get; set; } = new List<Quarto>
    {
        new Quarto()
        {
            Descricao = "Suíte Luxo",
            ValorDiariaAdulto = 150.0,
            ValorDiariaCrianca = 75.0
        },
        new Quarto()
        {
            Descricao = "Suíte Executiva",
            ValorDiariaAdulto = 100.0,
            ValorDiariaCrianca = 50.0
        },
        new Quarto()
        {
            Descricao = "Suíte Simples",
            ValorDiariaAdulto = 70.0,
            ValorDiariaCrianca = 35.0
        }
    };

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
    }
}