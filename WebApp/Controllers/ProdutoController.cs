using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Produto")]
    public class ProdutoController : ApiController
    {
        // GET: api/Produtos
        [HttpGet]
        [Route("RecuperarProdutos")]
        public IEnumerable<Produto> RecuperarProdutos()
        {
            return BaseProdutos.Produtos();
        }

        [HttpGet]
        [Route("RecuperarObjAnonimos")]
        public IEnumerable<object> RecuperarObjAnonimos()
        {
            var v1 = new { Amount = 108, Message = "Hello" };
            var v2 = new { Amount = 108, Message = "Hello" };
            var v4 = new { Amount = 108, Message = "Hello", obj1 = new { id = 1, nome = "primeiro" , obj2 = new { id = 1, descicao = "decricao 1" } } };

            return new object[] { v1, v2, v4 };
        }

        // GET: api/Produtos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produtos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produtos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produtos/5
        public void Delete(int id)
        {
        }
    }
}
