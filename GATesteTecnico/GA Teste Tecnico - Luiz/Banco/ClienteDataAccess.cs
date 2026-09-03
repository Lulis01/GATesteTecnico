using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using GATesteTecnico.Modelo;

namespace GATesteTecnico.Banco
{
    public static class ClienteDataAccess
    {
        private static string GetConnectionString()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Banco", "BancoLocacaoFerramentas.sdf");
            return "Data Source=" + dbPath;
        }

        public static List<Cliente> PegarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "SELECT * FROM [Cliente] ORDER BY Nome";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                con.Open();
                using (SqlCeDataReader resposta = comando.ExecuteReader())
                {
                    while (resposta.Read())
                    {
                        Cliente c = new Cliente();
                        c.Id = resposta.GetInt32(resposta.GetOrdinal("Id"));
                        c.Nome = resposta.GetString(resposta.GetOrdinal("Nome"));
                        c.CPF = resposta.GetString(resposta.GetOrdinal("CPF"));
                        c.Telefone = resposta.IsDBNull(resposta.GetOrdinal("Telefone")) ? null : resposta.GetString(resposta.GetOrdinal("Telefone"));
                        
                        clientes.Add(c);
                    }
                }
            }
            return clientes;
        }

        public static Cliente PegarCliente(int id)
        {
            Cliente cliente = null;
            string sql = "SELECT * FROM [Cliente] WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                con.Open();
                using (SqlCeDataReader resposta = comando.ExecuteReader())
                {
                    if (resposta.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = resposta.GetInt32(resposta.GetOrdinal("Id"));
                        cliente.Nome = resposta.GetString(resposta.GetOrdinal("Nome"));
                        cliente.CPF = resposta.GetString(resposta.GetOrdinal("CPF"));
                        cliente.Telefone = resposta.IsDBNull(resposta.GetOrdinal("Telefone")) ? null : resposta.GetString(resposta.GetOrdinal("Telefone"));
                        cliente.Email = resposta.IsDBNull(resposta.GetOrdinal("Email")) ? null : resposta.GetString(resposta.GetOrdinal("Email"));
                        
                        
                    }
                }
            }
            return cliente;
        }

         public static bool CPFJaExiste(string cpf, int idExcluir = 0)
        {
            string cpfLimpo = cpf.Replace(".", "").Replace("-", "");
            string sql = "SELECT COUNT(*) FROM [Cliente] WHERE CPF = @CPF AND Id != @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@CPF", cpfLimpo);
                comando.Parameters.AddWithValue("@Id", idExcluir);
                con.Open();
                int count = (int)comando.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool SalvarCliente(Cliente cliente)
        {
            if (CPFJaExiste(cliente.CPF))
                return false;

            string sql = "INSERT INTO [Cliente] (Nome, CPF, Telefone, Email) VALUES (@Nome, @CPF, @Telefone, @Email)";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@CPF", cliente.CPF.Replace(".", "").Replace("-", ""));
                comando.Parameters.AddWithValue("@Telefone", (object)cliente.Telefone ?? DBNull.Value);
                comando.Parameters.AddWithValue("@Email", (object)cliente.Email ?? DBNull.Value);


                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool AtualizarCliente(Cliente cliente)
        {
            string sql = "UPDATE [Cliente] SET Nome = @Nome, Telefone = @Telefone, Email = @Email WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", cliente.Id);
                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@Telefone", (object)cliente.Telefone ?? DBNull.Value);
                comando.Parameters.AddWithValue("@Email", (object)cliente.Email ?? DBNull.Value);
                

                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeletarCliente(int id)
        {
            string sql = "DELETE FROM [Cliente] WHERE Id = @Id";

            using (SqlCeConnection con = new SqlCeConnection(GetConnectionString()))
            using (SqlCeCommand comando = new SqlCeCommand(sql, con))
            {
                comando.Parameters.AddWithValue("@Id", id);
                con.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        
    }
}
