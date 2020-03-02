using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Enums;
using Senai.Peoples.WebApi.Interfaces;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string StringConexao = "Data Source =DEV14\\SQLEXPRESS; initial catalog =T_Peoples; user Id =sa; pwd =sa@132";
        public void Atualizar(int id, UsuariosDomain usuarioJson)
        {
            throw new System.NotImplementedException();
        }

        public UsuariosDomain BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(UsuariosDomain usuarioJson)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "insert into Usuarios values (@Email,@Senha,@IdFuncionario,@IdTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", usuarioJson.Email);

                    cmd.Parameters.AddWithValue("@Senha", usuarioJson.Senha);

                    cmd.Parameters.AddWithValue("@IdFuncionario", usuarioJson.IdFuncionario);

                    usuarioJson.IdTipoUsuario = (int)TipoUsuario.Comum;

                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuarioJson.IdTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> usuarios = new List<UsuariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdUsuario,Email,Senha,IdTipoUsuario, Funcionarios.Nome , Funcionarios.Sobrenome from Usuarios inner join Funcionarios on Funcionarios.IdFuncionario = Usuarios.IdFuncionario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        
                        UsuariosDomain usuario = new UsuariosDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            IdTipoUsuario = (int)TipoUsuario.Comum
                        };

                        usuario.Funcionario.Nome = rdr["Nome"].ToString();

                        usuario.Funcionario.Sobrenome = rdr["Sobrenome"].ToString();

                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }
    }
}