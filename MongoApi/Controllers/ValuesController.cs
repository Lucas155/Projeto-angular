using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using Nest;

namespace MongoApi.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ValuesController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produtos>> Get() =>
            _produtoService.Get();
        
         [HttpGet("{id}")]
        public ActionResult<Produtos> Get(string id)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [EnableCors("AllowMyOrigin")]
        [HttpPost]
        public ActionResult<Produtos> Create(Produtos produtos)
        {
            _produtoService.Create(produtos);

            return CreatedAtRoute("GetProduto", new { id = produtos._id.ToString() }, produtos);
        }

        [EnableCors("AllowMyOrigin")]
        [HttpPut("{id}")]
        public IActionResult Update(string id, Produtos produtosIn)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Update(id, produtosIn);
            
            return NoContent();
        }

        [EnableCors("AllowMyOrigin")]
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Remove(produto._id);

            return NoContent();
        }

    }
}
