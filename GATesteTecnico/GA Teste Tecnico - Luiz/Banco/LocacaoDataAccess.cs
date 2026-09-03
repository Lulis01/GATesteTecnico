using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using GATesteTecnico.Modelo;

namespace GATesteTecnico.Banco
{
    public static class LocacaoDataAccess
    {
        private static string GetConnectionString()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Banco", "BancoLocacaoFerramentas.sdf");
            return "Data Source=" + dbPath;
        }

        public static bool SalvarLocacao(Locacao locacao)
        {
            string sql = "INSERT INTO [Locacao] (ClienteId, ItemId, DataRetirada, DataPrevistaDevolucao, DataDevolucao, ValorTotal) " +
                         "VALUES (@ClienteId, @ItemId, @DataRetirada, @DataPrevistaDevolucao, @DataDevolucao, @ValorTotal)";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@ClienteId", locacao.ClienteId);
                comando.Parameters.AddWithValue("@ItemId", locacao.ItemId);
                comando.Parameters.AddWithValue("@DataRetirada", locacao.DataRetirada);
                comando.Parameters.AddWithValue("@DataPrevistaDevolucao", locacao.DataPrevistaDevolucao);
                comando.Parameters.AddWithValue("@DataDevolucao", (object)locacao.DataDevolucao ?? DBNull.Value);
                comando.Parameters.AddWithValue("@ValorTotal", locacao.ValorTotal);


                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool AtualizarLocacao(Locacao locacao)
        {
            string sql = "UPDATE [Locacao] SET ClienteId = @ClienteId, ItemId = @ItemId, DataRetirada = @DataRetirada, " +
                         "DataPrevistaDevolucao = @DataPrevistaDevolucao, DataDevolucao = @DataDevolucao, ValorTotal = @ValorTotal " +
                         "WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", locacao.Id);
                comando.Parameters.AddWithValue("@ClienteId", locacao.ClienteId);
                comando.Parameters.AddWithValue("@ItemId", locacao.ItemId);
                comando.Parameters.AddWithValue("@DataRetirada", locacao.DataRetirada);
                comando.Parameters.AddWithValue("@DataPrevistaDevolucao", locacao.DataPrevistaDevolucao);
                comando.Parameters.AddWithValue("@DataDevolucao", (object)locacao.DataDevolucao ?? DBNull.Value);
                comando.Parameters.AddWithValue("@ValorTotal", locacao.ValorTotal);

                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }
        
        public static List<Locacao> PegarLocacoesAtivas()
        {
            return BuscarLocacoes(ativa: true);
        }

        
        public static List<Locacao> PegarLocacoesFinalizadas()
        {
            return BuscarLocacoes(ativa: false);
        }

        private static List<Locacao> BuscarLocacoes(bool ativa)
        {
            List<Locacao> locacoes = new List<Locacao>();
            string condicao = ativa ? "L.DataDevolucao IS NULL" : "L.DataDevolucao IS NOT NULL";
            string sql = $@"SELECT L.*, C.Nome AS ClienteNome, F.Nome AS ItemNome
                     FROM [Locacao] L
                     INNER JOIN [Cliente] C ON L.ClienteId = C.Id
                     INNER JOIN [Ferramenta] F ON L.ItemId = F.Id
                     WHERE {condicao}
                     ORDER BY L.DataRetirada DESC";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                con.Open();
                using (SqlCeDataReader resposta = comando.ExecuteReader())
                {
                    while (resposta.Read())
                    {
                        locacoes.Add(LerLocacao(resposta));
                    }
                }
            }
            return locacoes;
        }

        public static Locacao PegarLocacao(int id)
        {
            Locacao loc = null;
            string sql = @"SELECT L.*, C.Nome AS ClienteNome, F.Nome AS ItemNome
                    FROM [Locacao] L
                    INNER JOIN [Cliente] C ON L.ClienteId = C.Id
                    INNER JOIN [Ferramenta] F ON L.ItemId = F.Id
                    WHERE L.Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                con.Open();
                using (SqlCeDataReader resposta = comando.ExecuteReader())
                {
                    if (resposta.Read())
                    {
                        loc = LerLocacao(resposta);
                    }
                }
            }
            return loc;
        }

        public static bool FinalizarLocacao(int id, DateTime dataDevolucao)
        {
            Locacao locacao = PegarLocacao(id);
            if (locacao == null)
            {
                return false;
            }

            const decimal MultaAtraso = 100m;

            int diasAtraso = (dataDevolucao.Date - locacao.DataPrevistaDevolucao.Date).Days;
            if (diasAtraso > 0)
            {
                locacao.ValorTotal += MultaAtraso * diasAtraso;
            }

            string sql = "UPDATE [Locacao] SET DataDevolucao = @DataDevolucao WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@DataDevolucao", dataDevolucao);

                con.Open();
                if (comando.ExecuteNonQuery() <= 0)
                {
                    return false;
                }
            }

            ItemDataAccess.AtualizarStatusItem(locacao.ItemId, StatusItem.Disponivel);
            return true;
        }

        public static decimal CalcularValorInicialLocacao(int itemId, int dias)
        {
            Item item = ItemDataAccess.PegarItem(itemId);
            if (item != null)
            {
                return item.ValorDiaria * dias;
            }
            return 0;
        }

        private static Locacao LerLocacao(SqlCeDataReader resposta)
        {
            Locacao loc = new Locacao();
            loc.Id = resposta.GetInt32(resposta.GetOrdinal("Id"));
            loc.ClienteId = resposta.GetInt32(resposta.GetOrdinal("ClienteId"));
            loc.ItemId = resposta.GetInt32(resposta.GetOrdinal("ItemId"));
            loc.ClienteNome = resposta.GetString(resposta.GetOrdinal("ClienteNome"));
            loc.ItemNome = resposta.GetString(resposta.GetOrdinal("ItemNome"));
            loc.DataRetirada = resposta.GetDateTime(resposta.GetOrdinal("DataRetirada"));
            loc.DataPrevistaDevolucao = resposta.GetDateTime(resposta.GetOrdinal("DataPrevistaDevolucao"));
            if (!resposta.IsDBNull(resposta.GetOrdinal("DataDevolucao")))
            {
                loc.DataDevolucao = resposta.GetDateTime(resposta.GetOrdinal("DataDevolucao"));
            }
            loc.ValorTotal = resposta.GetDecimal(resposta.GetOrdinal("ValorTotal"));

            return loc;
        }
    }
}