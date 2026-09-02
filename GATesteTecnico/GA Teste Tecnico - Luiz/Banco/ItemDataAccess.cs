using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using GATesteTecnico.Modelo;

namespace GATesteTecnico.Banco
{
    public static class ItemDataAccess
    {
        private static string GetConnectionString()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Banco", "BancoLocacaoFerramentas.sdf");
            return "Data Source=" + dbPath;
        }

        public static List<Item> PegarItens()
        {
            List<Item> itens = new List<Item>();
            string sql = "SELECT * FROM [Ferramenta] ORDER BY Nome";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                con.Open();
                using (SqlCeDataReader resposta = comando.ExecuteReader())
                {
                    while (resposta.Read())
                    {
                        Item i = new Item();
                        i.Id = resposta.GetInt32(resposta.GetOrdinal("Id"));
                        i.Nome = resposta.GetString(resposta.GetOrdinal("Nome"));
                        i.Categoria = resposta.GetString(resposta.GetOrdinal("Categoria"));
                        i.ValorDiaria = resposta.GetDecimal(resposta.GetOrdinal("ValorDiária"));
                        i.Status = (StatusItem)Enum.Parse(typeof(StatusItem), resposta.GetString(resposta.GetOrdinal("Status")));


                        itens.Add(i);
                    }
                }
            }
            return itens;
        }

        public static Item PegarItem(int id)
        {
            Item item = null;
            string sql = "SELECT * FROM [Ferramenta] WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                con.Open();
                using (SqlCeDataReader resposta = comando.ExecuteReader())
                {
                    if (resposta.Read())
                    {
                        item = new Item();
                        item.Id = resposta.GetInt32(resposta.GetOrdinal("Id"));
                        item.Nome = resposta.GetString(resposta.GetOrdinal("Nome"));
                        item.Categoria = resposta.GetString(resposta.GetOrdinal("Categoria"));
                        item.ValorDiaria = resposta.GetDecimal(resposta.GetOrdinal("ValorDiária"));
                        item.Status = (StatusItem)Enum.Parse(typeof(StatusItem), resposta.GetString(resposta.GetOrdinal("Status")));

                    }
                }
            }
            return item;
        }

        public static bool SalvarItem(Item item)
        {
            string sql = "INSERT INTO [Ferramenta] (Nome, Categoria, ValorDiária, Status) VALUES (@Nome, @Categoria, @ValorDiária, @Status)";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Nome", item.Nome);
                comando.Parameters.AddWithValue("@Categoria", item.Categoria);
                comando.Parameters.AddWithValue("@ValorDiária", item.ValorDiaria);
                comando.Parameters.AddWithValue("@Status", item.Status.ToString());


                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool AtualizarItem(Item item)
        {
            string sql = "UPDATE [Ferramenta] SET Nome = @Nome, Categoria = @Categoria, ValorDiária = @ValorDiária, Status = @Status WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", item.Id);
                comando.Parameters.AddWithValue("@Nome", item.Nome);
                comando.Parameters.AddWithValue("@Categoria", item.Categoria);
                comando.Parameters.AddWithValue("@ValorDiária", item.ValorDiaria);
                comando.Parameters.AddWithValue("@Status", item.Status.ToString());
                comando.Parameters.AddWithValue("@DataUpdate", DateTime.Now);

                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeletarItem(int id)
        {
            string sql = "DELETE FROM [Ferramenta] WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static void AtualizarStatusItem(int id, StatusItem novoStatus)
        {
            string sql = "UPDATE [Ferramenta] SET Status = @Status WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Status", novoStatus.ToString());


                con.Open();
                comando.ExecuteNonQuery();
            }
        }

        
    } 
}

