using Microsoft.AspNetCore.Mvc;
using MongoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosControllers : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosControllers(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produtos>> Get() =>
            _produtoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduto")]
        public ActionResult<Produtos> Get(string id)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult<Produtos> Create(Produtos produtos)
        {
            _produtoService.Create(produtos);

            return CreatedAtRoute("GetProduto", new { id = produtos._id.ToString() }, produtos);
        }

        [HttpPut("{id:length(24)}")]
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
