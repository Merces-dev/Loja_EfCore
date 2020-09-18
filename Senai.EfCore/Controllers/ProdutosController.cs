using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using Senai.EfCore.Repositories;
using Senai.EfCore.Utils;


namespace Senai.EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoRepository.Listar();


                if (produtos.Count == 0)
                    return NoContent();
                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, envie um e-mail para giovanitjs@gmail.com informando o mesmo"
                });
            }
        }

        // GET api/produtos/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                Produto produto = _produtoRepository.BuscarPorId(id);

                // Verifico se o produto foi encontrado e caso não exista retorno NotFounf
                if (produto == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        // POST api/produtos
        [HttpPost]
        public IActionResult Post([FromForm] Produto produto)
        {
            try
            {
                if (produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);
                    produto.UrlImagem = urlImagem;

                }
                _produtoRepository.Adicionar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/produtos/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/produtos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se produto existe e caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                _produtoRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}