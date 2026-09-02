using System;

namespace GATesteTecnico.Modelo
{
    public class Locacao
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int ItemId { get; set; }

        // Nomes para facilitar exibição
        public string ClienteNome { get; set; }
        public string ItemNome { get; set; }

        public DateTime DataRetirada { get; set; }

        public DateTime DataPrevistaDevolucao { get; set; }

        // Será preenchida quando a locação for finalizada
        public Nullable<DateTime> DataDevolucao { get; set; }

        public decimal ValorTotal { get; set; }

        // Status: 0 = Ativa, 1 = Finalizada
        public int Status { get; set; } // 0 = Ativa, 1 = Finalizada

        public DateTime DataCadastro { get; set; }
        public Nullable<DateTime> DataUpdate { get; set; }
    }
}

