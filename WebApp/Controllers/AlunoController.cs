using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Recuperar")]
        [Authorize]
        public IHttpActionResult Recuperar()
        {
            try
            {
                AlunoModel aluno = new AlunoModel();
                return Ok(aluno.listarAlunos());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Recuperar/{id}")]
        public IHttpActionResult RecuperarPorId(int id)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();
                AlunoDTO alunosRetorno = aluno.listarAlunos(id).FirstOrDefault();
                return Ok(alunosRetorno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}")]
        public IHttpActionResult RecuperarPorDataNome(string data, string nome)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();
                IEnumerable<AlunoDTO> alunosRetorno = aluno.listarAlunos()
                                        .Where(a => a.Data == data || a.Nome == nome);

                if (!alunosRetorno.Any())
                {
                    return NotFound();
                }

                return Ok(alunosRetorno);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        // POST: api/Aluno
        [HttpPost]
        public IHttpActionResult Post([FromBody]AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Inserir(aluno);

                return Ok(_aluno.listarAlunos());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        // PUT: api/Aluno/5
        [HttpPut]
        public IHttpActionResult Put(int id,[FromBody]AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();

                if (id == aluno.Id) 
                { 
                    _aluno.Atualizar(aluno);
                }
                else
                {
                    return Ok("Chave do aluno não compativel");
                }

                return Ok("Atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // DELETE: api/Aluno/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                _aluno.Deletar(id);

                return Ok("Deletado com sucesso");
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
