using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMaioresTimes.DAO
{
    public class TimeDAO
    {
        public List<TimeDTO> ListarTimes()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM Times";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var times = new List<TimeDTO>();

            while (dataReader.Read())
            {
                var time = new TimeDTO();
                time.ID = int.Parse(dataReader["ID"].ToString());
                time.Nome = dataReader["Nome"].ToString();
                time.LocalFundacao = dataReader["LocalFundacao"].ToString();
                time.Estadio = dataReader["Estadio"].ToString();
                time.Titulos = int.Parse(dataReader["Titulos"].ToString());
                time.Fundacao = Convert.ToDateTime(dataReader["Fundacao"]);

                times.Add(time);
            }

            conexao.Close();
            return times;

        }

        public void CadastrarTime(TimeDTO time)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Times (Nome, LocalFundacao, Estadio, Titulos, Fundacao) VALUES
						(@nome,@LocalFundacao,@Estadio,@Titulos,@Fundacao)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", time.Nome);
            comando.Parameters.AddWithValue("@LocalFundacao", time.LocalFundacao);
            comando.Parameters.AddWithValue("@Estadio", time.Estadio);
            comando.Parameters.AddWithValue("@Titulos", time.Titulos);
            comando.Parameters.AddWithValue("@Fundacao", time.Fundacao);

            comando.ExecuteNonQuery();
            conexao.Close();
        
        }

        public void AlterarTime(TimeDTO time)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"UPDATE Times SET 
                        Nome = @nome,
                        LocalFundacao = @LocalFundacao,
                        Estadio =@Estadio,
                        Titulos =@Titulos,
                        Fundacao = @Fundacao
                        WHERE ID = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", time.ID);
            comando.Parameters.AddWithValue("@nome", time.Nome);
            comando.Parameters.AddWithValue("@LocalFundacao", time.LocalFundacao);
            comando.Parameters.AddWithValue("@Estadio", time.Estadio);
            comando.Parameters.AddWithValue("@Titulos", time.Titulos);
            comando.Parameters.AddWithValue("@Fundacao", time.Fundacao);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void RemoverTime(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"DELETE FROM Times WHERE ID = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
