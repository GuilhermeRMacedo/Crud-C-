using Entidades;
using Interefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BDDao
{
    public class PessoaDao : IPessoaDao
    {
        /// <summary>
        /// Fornece a string de conexao
        /// </summary>
        /// <returns></returns>
        private String Sql_Con()
        {
            String Sql_Con = @"Server=(localdb)\MSSQLLocalDB; 
                               Database=Ex1.Pessoas.Estagio;
                               Integrated Security = true";
            return Sql_Con;
        }

        public void AdicionarPessoa(Pessoa p)
        {
            SqlConnection con = new SqlConnection(Sql_Con());
            con.Open();

            String SqlQuery = "INSERT INTO PESSOA VALUES (@nome, @idade)";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@idade", p.Idade);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void AlterarPessoa(int id, string nome, int idade)
        {
            SqlConnection con = new SqlConnection(Sql_Con());
            con.Open();

            String SqlQuery = "UPDATE PESSOA SET nome=@nome, idade=@idade WHERE id=@id";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@idade", idade);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ExcluirPessoaPorId(int id)
        {
            SqlConnection con = new SqlConnection(Sql_Con());
            con.Open();

            String SqlQuery = "DELETE FROM PESSOA WHERE ID=@id ";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public Pessoa PesquisarPessoaPorId(int id)
        {
            SqlConnection con = new SqlConnection(Sql_Con());

            con.Open();

            String SqlQuery = "SELECT * FROM PESSOA WHERE ID = @id";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            //Mapeamento de entidade
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = dr["nome"].ToString();
            pessoa.Idade = Convert.ToInt32(dr["idade"]);

            dr.Close();
            con.Close();

            return pessoa;
        }

        public List<Pessoa> PesquisarPorSubstring(string substring)
        {
            List<Pessoa> listaDePessoas = new List<Pessoa>();
            SqlConnection con = new SqlConnection(Sql_Con());
            con.Open();

            string SqlQuery = "SELECT * FROM PESSOA WHERE NOME LIKE @substring";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@substring", "%"+substring+"%");

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = dr["nome"].ToString();
            pessoa.Idade = Convert.ToInt32(dr["idade"]);

            listaDePessoas.Add(pessoa);

            /*while (!dr.Read())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = dr["nome"].ToString();
                pessoa.Idade = Convert.ToInt32(dr["idade"]);

                listaDePessoas.Add(pessoa);
            }*/

            return listaDePessoas;
        }
    }
}
