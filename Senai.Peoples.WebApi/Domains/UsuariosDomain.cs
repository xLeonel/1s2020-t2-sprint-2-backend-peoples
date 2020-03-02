using Senai.Peoples.WebApi.Enums;

namespace Senai.Peoples.WebApi.Domains
{
    public class UsuariosDomain
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //  USAR ESSE ID PARA ATUALIZAR OBJETO NULL
        public int IdFuncionario { get; set; }
        public FuncionariosDomain Funcionario {get;set;}
        public int IdTipoUsuario { get; set; }

        public UsuariosDomain ()
        {
            Funcionario = new FuncionariosDomain();
            // this.IdTipoUsuario = (int) TipoUsuario.Comum;
        }

    }
}