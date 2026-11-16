
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        // Configuração do Check-in
        DateTime hoje = DateTime.Today;

        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkin.MaximumDate = hoje.AddMonths(1);

        // Configuração do Check-out
        DateTime dataCheckIn = dtpck_checkin.Date ?? hoje;

        dtpck_checkout.MinimumDate = dataCheckIn.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckIn.AddMonths(6);
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlertAsync("Atenção", "Mensagem", "OK");
                return;
            }

            DateTime checkIn = dtpck_checkin.Date ?? DateTime.Today;
            DateTime checkOut = dtpck_checkout.Date ?? checkIn.AddDays(1);

            if (checkOut <= checkIn)
            {
                await DisplayAlertAsync("Atenção", "Mensagem", "OK");
                return;
            }

            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = checkIn,
                DataCheckOut = checkOut
            };

            await Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (Exception)
        {
            await DisplayAlertAsync("Ops", "Ocorreu um erro inesperado.", "OK");
        }
    }

    private void dtpck_checkin_DateSelected(
        object? sender, DateChangedEventArgs e)
    {
        DatePicker elemento = (DatePicker)sender;

        DateTime dataCheckIn = elemento.Date ?? DateTime.Today;

        dtpck_checkout.MinimumDate = dataCheckIn.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckIn.AddMonths(6);

        // Se o check-out ficou antes da nova data mínima,
        // atualiza para o dia seguinte ao check-in.
        if (dtpck_checkout.Date == null ||
            dtpck_checkout.Date <= dataCheckIn)
        {
            dtpck_checkout.Date = dataCheckIn.AddDays(1);
        }
    }

    private async void Sobre_Clicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
