using Senai.EfCore.Domains;
using System;
using System.Collections.Generic;

namespace Senai.EfCore.Interfaces
{
    public interface IPedidoRepository
    {
        /// <summary>
        /// Lista todos os Pedidos
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        List<Pedido> Listar();

        /// <summary>
        /// Busca por um pedido através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O pedido através do Id</returns>
        Pedido BuscarPorId(Guid id);

        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}