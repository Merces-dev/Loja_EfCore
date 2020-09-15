
using Microsoft.EntityFrameworkCore;
using Senai.EfCore.Contexts;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Senai.EfCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _ctx;
        public PedidoRepository()
        {
            _ctx = new PedidosContext();
        }
        #region gravacao

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                };


                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id,
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                _ctx.Pedidos.Add(pedido);
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region leitura
        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id); //Inner Join
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
}
        #endregion
