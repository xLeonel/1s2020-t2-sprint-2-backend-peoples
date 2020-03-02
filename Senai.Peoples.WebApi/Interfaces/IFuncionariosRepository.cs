using System.Collections.Generic;
using Senai.Peoples.WebApi.Domains;

namespace Senai.Peoples.WebApi.Interfaces
{
    public interface IFuncionariosRepository
    {
        List<FuncionariosDomain> Listar();
        List<FuncionariosDomain> ListarNomeCompleto();
        List<FuncionariosDomain> ListarOrdenado(string ordem);
        FuncionariosDomain BuscarPorID(int Id);
        FuncionariosDomain BuscarNome(string Nome);
        void Cadastrar(FuncionariosDomain funcionarioJSON);
        void Atualizar(int Id, FuncionariosDomain funcionarioJSON);
        void Deletar(int Id);
    }
}