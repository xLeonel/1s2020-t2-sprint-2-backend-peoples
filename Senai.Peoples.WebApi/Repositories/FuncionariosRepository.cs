using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Enums;
using Senai.Peoples.WebApi.Interfaces;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private string StringConexao = "Data Source =DEV14\\SQLEXPRESS; initial catalog =T_Peoples; user Id =sa; pwd =sa@132";

        public void Atualizar(int Id, FuncionariosDomain funcionarioJSON)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "update Funcionarios set Nome = @Nome, Sobrenome = @Sobrenome where IdFuncionario = @Id ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cmd.Parameters.AddWithValue("@Nome", funcionarioJSON.Nome);

                    if (String.IsNullOrEmpty(funcionarioJSON.Sobrenome))
                    {
                        FuncionariosDomain funcionario = BuscarPorID(Id);
                        cmd.Parameters.AddWithValue("@Sobrenome",funcionario.Sobrenome);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Sobrenome", funcionarioJSON.Sobrenome);
                    }

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarPorID(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select * from Funcionarios where IdFuncionario = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr;

                    cmd.Parameters.AddWithValue("@Id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString(),

                        };

                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public FuncionariosDomain BuscarNome(string Nome)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "exec BuscarFuncionario @Nome";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr;

                    cmd.Parameters.AddWithValue("@Nome", Nome);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString(),

                        };

                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public List<FuncionariosDomain> ListarNomeCompleto()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, CONCAT (Nome, ' ', Sobrenome) FROM Funcionarios";

                // Outra forma
                //string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                        
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            Nome = rdr[1].ToString(), 

                            // Outra forma
                            //,Nome = rdr["Nome"].ToString() + ' ' + rdr["Sobrenome"].ToString()

                            // se usar data nascimento
                            // ,DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public List<FuncionariosDomain> ListarOrdenado(string ordem)
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = $"SELECT IdFuncionario, Nome, Sobrenome from Funcionarios ORDER BY Nome {ordem}";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    { 
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public void Cadastrar(FuncionariosDomain funcionarioJSON)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryadd = "insert into Funcionarios values(@Nome, @Sobrenome)";
                
                using (SqlCommand cmd = new SqlCommand(queryadd, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioJSON.Nome);

                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioJSON.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "delete from Funcionarios where IdFuncionario = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdFuncionario, Nome, Sobrenome from Funcionarios";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString(),

                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}