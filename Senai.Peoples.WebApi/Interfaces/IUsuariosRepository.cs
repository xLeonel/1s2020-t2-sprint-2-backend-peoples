using System.Collections.Generic;
using Senai.Peoples.WebApi.Domains;

namespace Senai.Peoples.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        void Cadastrar(UsuariosDomain usuarioJson);
        List<UsuariosDomain> Listar();
        UsuariosDomain BuscarPorId(int id);
        void Atualizar(int id, UsuariosDomain usuarioJson);
        void Deletar(int id);

    }
}