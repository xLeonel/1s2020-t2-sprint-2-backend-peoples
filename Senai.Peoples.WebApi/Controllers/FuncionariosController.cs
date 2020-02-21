using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepository { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<FuncionariosDomain>> Get()
        {
            List<FuncionariosDomain> funcionarios = _funcionariosRepository.Listar();

            return Ok(funcionarios);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int Id)
        {
            FuncionariosDomain funcionarioSelecionado = _funcionariosRepository.BuscarPorID(Id);

            return Ok(funcionarioSelecionado);
        }

        [HttpGet("[action]/{nome}")]
        public ActionResult Buscar(string Nome)
        {
            FuncionariosDomain funcionarioSelecionado = _funcionariosRepository.BuscarNome(Nome);

            return Ok(funcionarioSelecionado);
        }


        // POST api/values
        [HttpPost]
        public ActionResult Post(FuncionariosDomain funcionarioJSON)
        {
            _funcionariosRepository.Cadastrar(funcionarioJSON);

            return Ok("Inserido");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int Id, FuncionariosDomain funcionarioJSON)
        {
            _funcionariosRepository.Atualizar(Id, funcionarioJSON);

            return Ok("Atualizado");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _funcionariosRepository.Deletar(id);

            return Ok("Deletado");
        }
    }
}
