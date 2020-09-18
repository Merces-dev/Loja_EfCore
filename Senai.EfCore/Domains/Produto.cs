using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    /// <summary>
    /// Define a classe produto que herda de BaseDomain
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        [NotMapped] // Não mapeia a propriedade no banco
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }
        //Relacionamento com a tabela PedidoItem 1,N
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
