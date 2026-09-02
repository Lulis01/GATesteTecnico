using System;

namespace GATesteTecnico.Modelo
{
    public enum StatusItem
    {
        Disponivel,
        Locado,
        Manutencao
    }

    public class Item
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal ValorDiaria { get; set; }

        public StatusItem Status { get; set; }

        public DateTime DataCadastro { get; set; }
        public Nullable<DateTime> DataUpdate { get; set; }
    }
}

