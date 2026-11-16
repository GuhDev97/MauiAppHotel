namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto? QuartoSelecionado { get; set; }
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Propriedade que calcula o total de dias da estadia
        public int TotalDias
        {
            get
            {
                int dias = (DataCheckOut - DataCheckIn).Days;
                return dias > 0 ? dias : 1;
            }
        }

        // Propriedade que calcula o valor total da hospedagem
        public double ValorTotal
        {
            get
            {
                double valorAdultos = 0;
                double valorCriancas = 0;

                if (QuartoSelecionado != null)
                {
                    double precoAdulto = QuartoSelecionado.ValorDiariaAdulto > 0 ? QuartoSelecionado.ValorDiariaAdulto : QuartoSelecionado.ValorDiaria;
                    double precoCrianca = QuartoSelecionado.ValorDiariaCrianca > 0 ? QuartoSelecionado.ValorDiariaCrianca : QuartoSelecionado.ValorDiaria;

                    valorAdultos = QntAdultos * precoAdulto;
                    valorCriancas = QntCriancas * precoCrianca;
                }

                return (valorAdultos + valorCriancas) * TotalDias;
            }
        }
    }
}